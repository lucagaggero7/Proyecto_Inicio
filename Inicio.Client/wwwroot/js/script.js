

function mostrarAlerta(mensaje) {
    Swal.fire({
        title: 'Éxito',
        text: mensaje,
        icon: 'success',
        confirmButtonText: 'Aceptar'
    });
}
function mostrarSpinner() {
    document.getElementById('spinner').style.display = 'block';
}

function ocultarSpinner() {
    document.getElementById('spinner').style.display = 'none';
}
