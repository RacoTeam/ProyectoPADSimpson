let cursor = document.getElementById("cursor");
let homerElement = document.getElementById('homer');
export function initializeHomerDonut() {

    window.addEventListener('mousemove', handleMouseMove);
    document.getElementById("homero-componente").addEventListener("mousemove", handleCursor);
}

function handleCursor(e) {
    var mouseX = e.pageX;
    var mouseY = e.pageY;
    cursor.style.left = (mouseX - 55) + "px";
    cursor.style.top = (mouseY - 55) + "px";
}

function handleMouseMove(e) {
    var x = e.pageX;
    var y = e.pageY;

    // Obtén las coordenadas relativas al homero-componente
    var rect = homerElement.getBoundingClientRect();
    var relativeX = x - rect.left;
    var relativeY = y - rect.top;

    // Realiza los cálculos en relación con el homero-componente
    if (relativeX < rect.width / 2 - 70) {
        homerElement.src = 'https://s3-us-west-2.amazonaws.com/s.cdpn.io/341817/homer_bottom-left.svg';
    } else if (relativeX > rect.width / 2 + 70) {
        homerElement.src = 'https://s3-us-west-2.amazonaws.com/s.cdpn.io/341817/homer_bottom-right.svg';
    } else if (Math.abs(relativeX - rect.width / 2) < 70) {
        homerElement.src = 'https://s3-us-west-2.amazonaws.com/s.cdpn.io/341817/homer_top-center.svg';
    }

    if (relativeX < rect.width / 2 - 70 && relativeY < rect.height / 2) {
        homerElement.src = 'https://s3-us-west-2.amazonaws.com/s.cdpn.io/341817/homer_top-left.svg';
    } else if (relativeX > rect.width / 2 + 70 && relativeY < rect.height / 2) {
        homerElement.src = 'https://s3-us-west-2.amazonaws.com/s.cdpn.io/341817/homer_top-right.svg';
    }
}