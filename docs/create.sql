

--create table roles (
--	id int identity(1, 1) primary key,
--	[nombre] [nvarchar](150) NOT NULL,
--	[orden] [int] NULL default(0),
--	[observaciones] [nvarchar](250) NULL,
--	[registro_sesion_id] [int] NULL default(0),
--	[registro_fecha] [datetime] NULL default(getdate()),
--	[edicion_sesion_id] [int] NULL default(0),
--	[edicion_fecha] [datetime] NULL default(getdate()),
--	[borrado] [bit] NULL default(0),
--	[borrado_sesion_id] [int] NULL default(0),
--	[borrado_fecha] [datetime] NULL
--)


--create table perfiles (
--	id int identity(1, 1) primary key,
--	[nombre] [nvarchar](150) NOT NULL,
--	[orden] [int] NULL default(0),
--	roles varchar(150) NULL,
--	[observaciones] [nvarchar](250) NULL,
--	[registro_sesion_id] [int] NULL default(0),
--	[registro_fecha] [datetime] NULL default(getdate()),
--	[edicion_sesion_id] [int] NULL default(0),
--	[edicion_fecha] [datetime] NULL default(getdate()),
--	[borrado] [bit] NULL default(0),
--	[borrado_sesion_id] [int] NULL default(0),
--	[borrado_fecha] [datetime] NULL
--)


--create table inicios_sesion (
--	id int identity(1, 1) primary key,
--	[usuario] [nvarchar](25) NOT NULL,
--	[clave] [nvarchar](50) NULL,
--	[nombre] [nvarchar](50) NULL,
--	[apellidos] [nvarchar](100) NULL,
--	[perfil_id] [int] NOT NULL,
--	[roles_id] [nvarchar](150) NULL,
--	[nivel] [int] NOT NULL,
--	[telefono] [nvarchar](15) NULL,
--	[email] [nvarchar](250) NULL,
--	[observaciones] [nvarchar](250) NULL,
--	[rol_id] int nuLL,
--	[registro_sesion_id] [int] NULL default(0),
--	[registro_fecha] [datetime] NULL default(getdate()),
--	[edicion_sesion_id] [int] NULL default(0),
--	[edicion_fecha] [datetime] NULL default(getdate()),
--	[borrado] [bit] NULL default(0),
--	[borrado_sesion_id] [int] NULL default(0),
--	[borrado_fecha] [datetime] NULL
--)


create table productos_marcas (
	id int identity(1, 1) primary key,	
	[nombre] [nvarchar](150) NOT NULL,
	[orden] [int] NULL default(0),
	[observaciones] [nvarchar](250) NULL,
	[registro_sesion_id] [int] NULL default(0),
	[registro_fecha] [datetime] NULL default(getdate()),
	[edicion_sesion_id] [int] NULL default(0),
	[edicion_fecha] [datetime] NULL default(getdate()),
	[borrado] [bit] NULL default(0),
	[borrado_sesion_id] [int] NULL default(0),
	[borrado_fecha] [datetime] NULL
)



create table productos_tallas (
	id int identity(1, 1) primary key,		
	[nombre] [nvarchar](150) NOT NULL,
	[nombre_corto] [nvarchar](3) NOT NULL,	
	[orden] [int] NULL default(0)	
)


create table productos_especificaciones (
	id int identity(1, 1) primary key,	
	[producto_id] [int] NOT NULL,
	[nombre] [nvarchar](100) NOT NULL,	
	[orden] [int] NULL default(0),	
	[registro_sesion_id] [int] NULL default(0),
	[registro_fecha] [datetime] NULL default(getdate()),
	[edicion_sesion_id] [int] NULL default(0),
	[edicion_fecha] [datetime] NULL default(getdate()),
	[borrado] [bit] NULL default(0),
	[borrado_sesion_id] [int] NULL default(0),
	[borrado_fecha] [datetime] NULL
)

create table productos_tipo (
	id int identity(1, 1) primary key,		
	[nombre] [nvarchar](100) NOT NULL,	
	[orden] [int] NULL default(0),	
	[registro_sesion_id] [int] NULL default(0),
	[registro_fecha] [datetime] NULL default(getdate()),
	[edicion_sesion_id] [int] NULL default(0),
	[edicion_fecha] [datetime] NULL default(getdate()),
	[borrado] [bit] NULL default(0),
	[borrado_sesion_id] [int] NULL default(0),
	[borrado_fecha] [datetime] NULL
)

create table productos_colores (
	id int identity(1, 1) primary key,		
	[nombre] [nvarchar](100) NOT NULL,	
	[orden] [int] NULL default(0),	
	[registro_sesion_id] [int] NULL default(0),
	[registro_fecha] [datetime] NULL default(getdate()),
	[edicion_sesion_id] [int] NULL default(0),
	[edicion_fecha] [datetime] NULL default(getdate()),
	[borrado] [bit] NULL default(0),
	[borrado_sesion_id] [int] NULL default(0),
	[borrado_fecha] [datetime] NULL
)

CREATE TABLE productos_stocks (
    id int identity(1, 1) primary key,
    id_producto INT NOT NULL,
    cantidad INT NOT NULL    
)

CREATE TABLE productos_transacciones (
    id int identity(1, 1) primary key,
    id_producto INT NOT NULL,
    tipo_transaccion varchar(50) NOT NULL, --Vendido, Reservado	
    fecha_transaccion Datetime NULL,
	formapago_id INT NULL,
    id_cliente INT NULL
)

CREATE TABLE transacciones_formaspago (
     id int identity(1, 1) primary key,
     metodo_pago VARCHAR(50) NOT NULL -- Ejemplo: Efectivo, Tarjeta de Crédito, PayPal, etc.
)

CREATE TABLE transaccion_cuotas (
    id int identity(1, 1) primary key,
    id_transaccion INT NOT NULL, -- Relacionada con la transacción
    numero_cuota INT NOT NULL, -- Número de la cuota (1, 2, 3, etc.)
    monto_cuota DECIMAL(10, 2) NOT NULL, -- Monto de la cuota
    fecha_vencimiento DATE NOT NULL, -- Fecha de vencimiento de la cuota
    fecha_pago DATE, -- Fecha en la que se realizó el pago (puede ser NULL si aún no está pagada)
    estado_pago varchar(30) DEFAULT 'Pendiente', -- Estado del pago de la cuota, 'Pendiente', 'Pagada'
    FOREIGN KEY (id_transaccion) REFERENCES productos_transacciones(id)
)

CREATE TABLE productos_fotos (
    id int identity(1, 1) primary key,
    id_producto INT NOT NULL, -- Relacionada con el producto   
    descripcion VARCHAR(255), -- Descripción de la foto (opcional)
    orden [int] NULL default(0),
	[registro_sesion_id] [int] default(0),
	[registro_fecha] [datetime] default(getdate()),
	[edicion_sesion_id] [int] default(0),
	[edicion_fecha] [datetime] default(getdate()),
	[borrado] [bit] default(0),
	[borrado_sesion_id] [int] default(0),
	[borrado_fecha] [datetime] 
)

CREATE TABLE fotos_detalle (
    id int identity(1, 1) primary key,
    foto_id INT NOT NULL, -- Relacionada con el producto   
    fotobinaria varbinary(max) NULL, 
    
)


create table productos (
	id int identity(1, 1) primary key,
	tipo_id int not null,
	marca_id int not null,
	color_id int not null,
	talla_id int not null,
	fecha_producto datetime,
	nombre nvarchar(100),
	descripcion nvarchar(500),
	precio_fabricante decimal(10, 2) NOT NULL,
	precio_compra decimal(10, 2) NOT NULL,
	precio_venta decimal(10, 2) NOT NULL,
	[observaciones] [nvarchar](250),
	[registro_sesion_id] [int] default(0),
	[registro_fecha] [datetime] default(getdate()),
	[edicion_sesion_id] [int] default(0),
	[edicion_fecha] [datetime] default(getdate()),
	[borrado] [bit] default(0),
	[borrado_sesion_id] [int] default(0),
	[borrado_fecha] [datetime] 
)






