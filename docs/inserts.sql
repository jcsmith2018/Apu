

-- roles de usuario
insert into roles(nombre) values ('Admin')
insert into roles(nombre) values ('Coordinad')


-- perfiles????
--insert into perfiles(nombre, roles) values ('Administrador/a', '')
--insert into perfiles(nombre, roles) values ('Técnico/a', '')
--insert into perfiles(nombre, roles) values ('Coordinador/a', '')




--tarea_categorias
insert into tarea_categorias (nombre) values ('BAJAS')
insert into tarea_categorias (nombre) values ('DISPOSITIVOS PERIFERICOS')
insert into tarea_categorias (nombre) values ('LLAVES')
insert into tarea_categorias (nombre) values ('OTROS')
insert into tarea_categorias (nombre) values ('PRIMERA CONEXIÓN')
insert into tarea_categorias (nombre) values ('TAD')
insert into tarea_categorias (nombre) values ('TELEMONITORIZACION')
insert into tarea_categorias (nombre) values ('UCR')

-- tarea_tipos
insert into tarea_tipos (categoria_id, urgente_id, orden, nombre) values (1,1,0,'NO FUNCIONA UCR')
insert into tarea_tipos (categoria_id, urgente_id, orden, nombre) values (1,1,0,'BAJA BATERIA UCR')
insert into tarea_tipos (categoria_id, urgente_id, orden, nombre) values (1,3,0,'RECOGER UCRS')
insert into tarea_tipos (categoria_id, urgente_id, orden, nombre) values (1,3,0,'CAMBIO DE SOPORTE')
insert into tarea_tipos (categoria_id, urgente_id, orden, nombre) values (1,2,0,'NUEVO USUARIO 10')
insert into tarea_tipos (categoria_id, urgente_id, orden, nombre) values (1,3,-1,'ADAPTADOR ROTO')
insert into tarea_tipos (categoria_id, urgente_id, orden, nombre) values (1,1,0,'PERDIDA UCR')
insert into tarea_tipos (categoria_id, urgente_id, orden, nombre) values (1,1,0,'ROTURA UCR')
insert into tarea_tipos (categoria_id, urgente_id, orden, nombre) values (1,3,0,'CAMBIO DE UCR POR PULSERA/COLGANTE')
insert into tarea_tipos (categoria_id, urgente_id, orden, nombre) values (1,1,0,'BAJA BATERIA UCR (TRAS ALARMA G)')
insert into tarea_tipos (categoria_id, urgente_id, orden, nombre) values (1,3,-1,'PERIFÉRICO DESASIGNADO')
insert into tarea_tipos (categoria_id, urgente_id, orden, nombre) values (1,3,0,'PERIFÉRICO MAL PROGRAMADO - DESASIGNADO')
insert into tarea_tipos (categoria_id, urgente_id, orden, nombre) values (1,4,0,'NO FUNCIONA UCR RIESGO SEVERO')
insert into tarea_tipos (categoria_id, urgente_id, orden, nombre) values (1,4,0,'PERDIDA UCR RIESGO SEVERO')
insert into tarea_tipos (categoria_id, urgente_id, orden, nombre) values (1,5,0,'NO FUNCIONA UCR RIESGO MODERADO')
insert into tarea_tipos (categoria_id, urgente_id, orden, nombre) values (1,5,0,'PERDIDA UCR RIESGO MODERADO')
insert into tarea_tipos (categoria_id, urgente_id, orden, nombre) values (2,3,0,'COMPROBAR LLAVES')
insert into tarea_tipos (categoria_id, urgente_id, orden, nombre) values (2,3,0,'DEVOLVER LLAVES')
insert into tarea_tipos (categoria_id, urgente_id, orden, nombre) values (2,2,0,'LLAVES PORTAL')
insert into tarea_tipos (categoria_id, urgente_id, orden, nombre) values (2,1,0,'LLAVES DOMICILIO')
insert into tarea_tipos (categoria_id, urgente_id, orden, nombre) values (3,3,0,'BAJA DEFINITIVA TAD')
insert into tarea_tipos (categoria_id, urgente_id, orden, nombre) values (3,3,0,'RETIRAR DISPOSITIVOS')
insert into tarea_tipos (categoria_id, urgente_id, orden, nombre) values (3,3,0,'RECOGER 2ª UCR')
insert into tarea_tipos (categoria_id, urgente_id, orden, nombre) values (4,3,0,'EQUIPO ANTIGUO')
insert into tarea_tipos (categoria_id, urgente_id, orden, nombre) values (4,4,0,'NO FUNCIONA TAD RIESGO SEVERO')
insert into tarea_tipos (categoria_id, urgente_id, orden, nombre) values (4,5,0,'NO FUNCIONA TAD RIESGO MODERADO')
insert into tarea_tipos (categoria_id, urgente_id, orden, nombre) values (4,2,-1,'NO FUNCIONA TAD - CAJA DE VOZ')
insert into tarea_tipos (categoria_id, urgente_id, orden, nombre) values (4,2,-1,'CAMBIO DE COMPAÑIA')
insert into tarea_tipos (categoria_id, urgente_id, orden, nombre) values (4,2,-1,'ROUTER GSM')
insert into tarea_tipos (categoria_id, urgente_id, orden, nombre) values (4,2,0,'NOVO')
insert into tarea_tipos (categoria_id, urgente_id, orden, nombre) values (4,1,0,'RUIDOS/PITIDOS/INTERFERENCIAS')
insert into tarea_tipos (categoria_id, urgente_id, orden, nombre) values (4,1,0,'NO FUNCIONA TAD')
insert into tarea_tipos (categoria_id, urgente_id, orden, nombre) values (4,1,0,'AVISOS LUMINOSOS NO JUSTIFICADOS')
insert into tarea_tipos (categoria_id, urgente_id, orden, nombre) values (4,1,0,'ALARMAS M/L NO JUSTIFICADAS')
insert into tarea_tipos (categoria_id, urgente_id, orden, nombre) values (4,3,0,'ALARMAS B NO JUSTIFICADAS')
insert into tarea_tipos (categoria_id, urgente_id, orden, nombre) values (4,1,0,'BAJA BATERIA DE TAD')
insert into tarea_tipos (categoria_id, urgente_id, orden, nombre) values (4,1,0,'EQUIPO DESASIGNADO/MAL PROGRAMADO')
insert into tarea_tipos (categoria_id, urgente_id, orden, nombre) values (4,1,0,'REPROGRAMACION POR FALLO EN LUCES')
insert into tarea_tipos (categoria_id, urgente_id, orden, nombre) values (4,3,0,'AUTOTEST INCORRECTO')
insert into tarea_tipos (categoria_id, urgente_id, orden, nombre) values (4,3,0,'ALARMAS R/I NO JUSTIFICADAS')
insert into tarea_tipos (categoria_id, urgente_id, orden, nombre) values (5,2,-1,'NO FUNCIONAN PERIFERICOS')
insert into tarea_tipos (categoria_id, urgente_id, orden, nombre) values (5,2,-1,'ALARMAS G DE DISPOSITIVOS')
insert into tarea_tipos (categoria_id, urgente_id, orden, nombre) values (5,2,-1,'BAJA BATERIA AVISADOR DE LLAMADA')
insert into tarea_tipos (categoria_id, urgente_id, orden, nombre) values (5,2,-1,'NO FUNCIONA AVISADOR DE LLAMADA')
insert into tarea_tipos (categoria_id, urgente_id, orden, nombre) values (5,2,0,'NO FUNCIONA PIRAMIDE LUMINOSA')
insert into tarea_tipos (categoria_id, urgente_id, orden, nombre) values (5,2,0,'BAJA BATERIA PIRAMIDE LUMINOSA')
insert into tarea_tipos (categoria_id, urgente_id, orden, nombre) values (5,2,0,'DISPOSITIVO ANTIGUO')
insert into tarea_tipos (categoria_id, urgente_id, orden, nombre) values (5,2,0,'NO FUNCIONA DISPOSITIVO GAS')
insert into tarea_tipos (categoria_id, urgente_id, orden, nombre) values (5,2,0,'NO FUNCIONA DISPOSITIVO HUMO')
insert into tarea_tipos (categoria_id, urgente_id, orden, nombre) values (5,2,-1,'NO FUNCIONA GPS')
insert into tarea_tipos (categoria_id, urgente_id, orden, nombre) values (5,2,-1,'NO FUNCIONA GSM')
insert into tarea_tipos (categoria_id, urgente_id, orden, nombre) values (5,2,-1,'NO FUNCIONA NEMO')
insert into tarea_tipos (categoria_id, urgente_id, orden, nombre) values (5,2,0,'NO FUNCIONA DISPOSITIVO PRESENCIA')
insert into tarea_tipos (categoria_id, urgente_id, orden, nombre) values (5,2,0,'NO FUNCIONA DISPOSITIVO APERTURA PUERTA')
insert into tarea_tipos (categoria_id, urgente_id, orden, nombre) values (5,2,-1,'NO FUNCIONA DISPOSITIVO MEDICACION')
insert into tarea_tipos (categoria_id, urgente_id, orden, nombre) values (5,2,0,'NO FUNCIONA DISPOSITIVO CAIDA')
insert into tarea_tipos (categoria_id, urgente_id, orden, nombre) values (5,2,-1,'NO FUNCIONA DISPOSITIVO SILLON/CAMA')
insert into tarea_tipos (categoria_id, urgente_id, orden, nombre) values (5,2,0,'BAJA BATERIA DISPOSITIVO GAS')
insert into tarea_tipos (categoria_id, urgente_id, orden, nombre) values (5,2,0,'BAJA BATERIA DISPOSITIVO HUMO')
insert into tarea_tipos (categoria_id, urgente_id, orden, nombre) values (5,2,-1,'BAJA BATERIA GPS')
insert into tarea_tipos (categoria_id, urgente_id, orden, nombre) values (5,2,-1,'BAJA BATERIA GSM')
insert into tarea_tipos (categoria_id, urgente_id, orden, nombre) values (5,2,-1,'BAJA BATERIA NEMO')
insert into tarea_tipos (categoria_id, urgente_id, orden, nombre) values (5,2,0,'BAJA BATERIA DISPOSITIVO PRESENCIA')
insert into tarea_tipos (categoria_id, urgente_id, orden, nombre) values (5,2,0,'BAJA BATERIA DISPOSITIVO APERTURA PUERTA')
insert into tarea_tipos (categoria_id, urgente_id, orden, nombre) values (5,2,-1,'BAJA BATERIA DISPOSITIVO MEDICACION')
insert into tarea_tipos (categoria_id, urgente_id, orden, nombre) values (5,2,0,'BAJA BATERIA DISPOSITIVO CAIDA')
insert into tarea_tipos (categoria_id, urgente_id, orden, nombre) values (5,2,-1,'BAJA BATERIA DISPOSITIVO SILLON/CAMA')
insert into tarea_tipos (categoria_id, urgente_id, orden, nombre) values (5,2,-1,'ROTURA/PERDIDA CARGADOR/TRANSFORMADOR')
insert into tarea_tipos (categoria_id, urgente_id, orden, nombre) values (5,3,0,'NO FUNCIONA RELOJ A')
insert into tarea_tipos (categoria_id, urgente_id, orden, nombre) values (6,1,-1,'1ª CONEXIÓN NEMO')
insert into tarea_tipos (categoria_id, urgente_id, orden, nombre) values (6,3,0,'1ª CONEXION  TAD ALTA NO URGENTE')
insert into tarea_tipos (categoria_id, urgente_id, orden, nombre) values (6,3,0,'PRIMERA CONEXION-RELOJ A')
insert into tarea_tipos (categoria_id, urgente_id, orden, nombre) values (6,3,0,'MEJORA DE INSTALACION/CAMBIO UBICACIÓN')
insert into tarea_tipos (categoria_id, urgente_id, orden, nombre) values (6,3,0,'CAMBIO DOMICILIO')
insert into tarea_tipos (categoria_id, urgente_id, orden, nombre) values (6,1,-1,'1ª CONEXION TAD MOVIL GPS')
insert into tarea_tipos (categoria_id, urgente_id, orden, nombre) values (6,1,0,'1ª CONEXION  TAD ALTA URGENTE')
insert into tarea_tipos (categoria_id, urgente_id, orden, nombre) values (6,3,-1,'CAMBIO DE UBICACION DEL EQUIPO')
insert into tarea_tipos (categoria_id, urgente_id, orden, nombre) values (6,3,0,'1ª CONEXION DISPOSITIVOS PERIFERICOS')
insert into tarea_tipos (categoria_id, urgente_id, orden, nombre) values (6,1,-1,'1ª CONEXION TAD MOVIL GSM')
insert into tarea_tipos (categoria_id, urgente_id, orden, nombre) values (7,3,0,'FIRMA DOCUMENTACION')
insert into tarea_tipos (categoria_id, urgente_id, orden, nombre) values (7,3,-1,'FACTURAS')
insert into tarea_tipos (categoria_id, urgente_id, orden, nombre) values (7,3,-1,'RECOGER REGALOS DE LOS USUARIOS')
insert into tarea_tipos (categoria_id, urgente_id, orden, nombre) values (7,3,-1,'TAREA SIN ESPECIFICAR')
insert into tarea_tipos (categoria_id, urgente_id, orden, nombre) values (7,3,-1,'ENTREGAR PULSERA QR')
insert into tarea_tipos (categoria_id, urgente_id, orden, nombre) values (8,1,-1,'PRIMERA CONEXIÓN')
insert into tarea_tipos (categoria_id, urgente_id, orden, nombre) values (8,1,-1,'TRÁS ALARMA')
insert into tarea_tipos (categoria_id, urgente_id, orden, nombre) values (9,2,0,'TELEMONITORIZACION')


-- contacto_categorias
insert into contacto_categorias (nombre) values ('Concertar Cita')
insert into contacto_categorias (nombre) values ('No Procede')
insert into contacto_categorias (nombre) values ('No Realizada')
insert into contacto_categorias (nombre) values ('Pospuesta')
insert into contacto_categorias (nombre) values ('Realizada')

-- contacto_motivos
insert into contacto_motivos (categoria_id, nombre) values (1,'No Contesta')
insert into contacto_motivos (categoria_id, nombre) values (1,'Llamar Otro Día')
insert into contacto_motivos (categoria_id, nombre) values (1,'Cita Concertada')
insert into contacto_motivos (categoria_id, nombre) values (2,'Realizada')
insert into contacto_motivos (categoria_id, nombre) values (3,'Usuario Ausente')
insert into contacto_motivos (categoria_id, nombre) values (3,'A Petición Usuario')
insert into contacto_motivos (categoria_id, nombre) values (3,'Motivos Técnicos en Domicilio')
insert into contacto_motivos (categoria_id, nombre) values (3,'Aplazada por Técnico')
insert into contacto_motivos (categoria_id, nombre) values (4,'Usuario Ausente')
insert into contacto_motivos (categoria_id, nombre) values (4,'A Petición Usuario')
insert into contacto_motivos (categoria_id, nombre) values (4,'Motivos Técnicos en Domicilio')
insert into contacto_motivos (categoria_id, nombre) values (4,'Aplazada por Técnico')
insert into contacto_motivos (categoria_id, nombre) values (5,'Solucionado en Domicilio')
insert into contacto_motivos (categoria_id, nombre) values (5,'No Incidencia Técnica')

-- urgente_tipos
insert into urgencias (nombre) values ('URGENTE 24H')
insert into urgencias (nombre) values ('NO URGENTE 48H')
insert into urgencias (nombre) values ('NO URGENTE 72H')
insert into urgencias (nombre) values ('MUY URGENTE 4H')
insert into urgencias (nombre) values ('MUY URGENTE 12H')

-- prioridades
insert into prioridades (nombre) values ('EXTREMA')
insert into prioridades (nombre) values ('ALTA')
insert into prioridades (nombre) values ('MEDIA-ALTA')
insert into prioridades (nombre) values ('MEDIA')
insert into prioridades (nombre) values ('MEDIA-BAJA')
insert into prioridades (nombre) values ('BAJA')









