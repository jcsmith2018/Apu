// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

"use strict";

const sigpadSize = 2;

const sigpadCanvasOptions = {
    width: [300, 450, 600][sigpadSize],
    height: [150, 225, 300][sigpadSize]
}


function checkSerial(e) {
    //test: '0300202237633'
    const device = $(this).data('device')
    const serial = $(this).siblings('.form-control').val()

    if (!serial) {
        alert('Debe indicar un número de serie válido')
        return
    }

    const url = (device == 'ucr') ? '/inventario/checkUcr' : '/inventario/checkTerminal'

    $.post(url, { serial: serial }).then(response => {
        //console.log(JSON.stringify(response))

        if (response.valido) {
            $(this).removeClass('bg-danger').addClass('bg-success text-white')
            alert(`${response.serial} es VÁLIDO`)
        }
        else {
            $(this).removeClass('bg-success').addClass('bg-danger text-white')
            alert(`${response.serial} NO ES válido`)
        }
    })
}