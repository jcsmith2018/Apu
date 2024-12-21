
select top 1500 
    'insert into usuarios_tad (
        sias,
        expediente,
        nombre,
        apellido1,
        apellido2,
        direccion,
        provincia,
        poblacion,
        codigo_postal,
        distrito,
        telefono,
        estado_nombre,
        estado_fecha,
        via_tipo,
        via_nombre,
        via_numero,
        via_escal,
        via_piso,
        via_puerta,
        programa,
        vive_solo,
        terminal_serie,
        terminal_secreto,
        ucr_serie,
        dispositivos,
        riesgo
    ) 
    values('+
        '''' + cast(codigousuario as nvarchar) + ''', ' +
        '''' + isnull(expediente, '') + ''', ' +
        '''' + isnull(nombre, '') + ''', ' +
        '''' + isnull(apellido1, '') + ''', ' +
        '''' + isnull(apellido2, '') + ''', ' +
        '''' + isnull(direccion, '') + ''', ' +
        '''' + isnull(provincia, '') + ''', ' +
        '''' + isnull(poblacion, '') + ''', ' +
        '''' + isnull(codigopostal, '') + ''', ' +
        '''' + isnull(distrito, '') + ''', ' +
        '''' + isnull(telefono, '') + ''', ' +
        '''' + isnull(situacion, '') + ''', ' +
        '''' + convert(varchar, fechasituacion, 103) + ''', ' +
        '''' + isnull(viatipo, '') + ''', ' +
        '''' + isnull(vianombre, '') + ''', ' +
        '''' + isnull(vianumero, '') + ''', ' +
        '''' + isnull(viaescaler, '') + ''', ' +
        '''' + isnull(viapiso, '') + ''', ' +
        '''' + isnull(viapuerta, '') + ''', ' +
        '''' + isnull(colectivo, '') + ''', ' +
        '''' + isnull(convivenciasolo, '') + ''', ' +
        '''' + isnull(numeroserieterminal, '') + ''', ' +
        '''' + isnull(NumeroSecretoTerminal, '') + ''', ' +
        '''' + isnull(numeroserieterminal, '') + ''', ' +
        '''' + isnull(DispositivosInstalados, '') + ''', ' +
        '''' + isnull(riesgo, '') + ''        
    +')' 
from 
    tblusutel
order by codigousuario desc