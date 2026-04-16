// DOM Elements
const betForm = document.getElementById('betForm');
const refreshBtn = document.getElementById('refreshBtn');
const formMessage = document.getElementById('formMessage');
const gamesTbody = document.getElementById('gamesTbody');
const usersTbody = document.getElementById('usersTbody');

// Event Listeners
betForm.addEventListener('submit', handleBetSubmit);
refreshBtn.addEventListener('click', loadStats);

// Cargar estadísticas al iniciar
document.addEventListener('DOMContentLoaded', loadStats);

/**
 * Manejar el envío del formulario de apuestas
 */
async function handleBetSubmit(event) {
    event.preventDefault();

    const userId = parseInt(document.getElementById('userId').value);
    const game = document.getElementById('game').value;
    const stake = parseFloat(document.getElementById('stake').value);
    const winAmount = parseFloat(document.getElementById('winAmount').value);

    const bet = {
        userId,
        game,
        stake,
        winAmount
    };

    try {
        const response = await fetch('/api/bets', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json',
            },
            body: JSON.stringify(bet)
        });

        const data = await response.json();

        if (response.ok) {
            showMessage('success', data.message || 'Apuesta registrada exitosamente.');
            betForm.reset();
            loadStats();
        } else {
            showMessage('danger', data.message || 'Error al registrar la apuesta.');
        }
    } catch (error) {
        console.error('Error:', error);
        showMessage('danger', 'Error de conexión con el servidor.');
    }
}

/**
 * Cargar estadísticas desde la API
 */
async function loadStats() {
    try {
        const response = await fetch('/api/bets/stats');

        if (!response.ok) {
            showMessage('danger', 'Error al cargar estadísticas.');
            return;
        }

        const data = await response.json();
        renderGameStats(data.games);
        renderUserStats(data.users);
    } catch (error) {
        console.error('Error:', error);
        showMessage('danger', 'Error al cargar estadísticas.');
    }
}

/**
 * Renderizar estadísticas por juego
 */
function renderGameStats(games) {
    if (!games || games.length === 0) {
        gamesTbody.innerHTML = `
            <tr>
                <td colspan="2" class="text-center text-muted">
                    Sin datos. Registra apuestas para ver estadísticas.
                </td>
            </tr>
        `;
        return;
    }

    gamesTbody.innerHTML = games.map(game => `
        <tr>
            <td><strong>${escapeHtml(game.game)}</strong></td>
            <td>
                <span class="badge bg-info">${game.rtp.toFixed(2)}%</span>
            </td>
        </tr>
    `).join('');
}

/**
 * Renderizar estadísticas por usuario
 */
function renderUserStats(users) {
    if (!users || users.length === 0) {
        usersTbody.innerHTML = `
            <tr>
                <td colspan="4" class="text-center text-muted">
                    Sin datos. Registra apuestas para ver estadísticas.
                </td>
            </tr>
        `;
        return;
    }

    usersTbody.innerHTML = users.map(user => {
        const balance = user.totalWin - user.totalStake;
        const balanceClass = balance >= 0 ? 'success' : 'danger';
        const balanceSign = balance >= 0 ? '+' : '';

        return `
            <tr>
                <td><strong>Usuario #${user.userId}</strong></td>
                <td>$${user.totalStake.toFixed(2)}</td>
                <td>$${user.totalWin.toFixed(2)}</td>
                <td>
                    <span class="badge bg-${balanceClass}">
                        ${balanceSign}$${balance.toFixed(2)}
                    </span>
                </td>
            </tr>
        `;
    }).join('');
}

/**
 * Mostrar mensaje de notificación
 */
function showMessage(type, message) {
    formMessage.innerHTML = `
        <div class="alert alert-${type} alert-dismissible fade show" role="alert">
            ${escapeHtml(message)}
            <button type="button" class="btn-close" data-bs-dismiss="alert" aria-label="Close"></button>
        </div>
    `;

    // Auto-descartar después de 5 segundos
    setTimeout(() => {
        const alert = formMessage.querySelector('.alert');
        if (alert) {
            alert.remove();
        }
    }, 5000);
}

/**
 * Escapar HTML para prevenir XSS
 */
function escapeHtml(text) {
    const map = {
        '&': '&amp;',
        '<': '&lt;',
        '>': '&gt;',
        '"': '&quot;',
        "'": '&#039;'
    };
    return text.replace(/[&<>"']/g, m => map[m]);
}
