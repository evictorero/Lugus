---BAse de Datos lugus
CREATE TABLE rPedidoBebida ( 
	id_pedidobebida int NOT NULL,
	id_pedido int NOT NULL,
	id_bebida int NOT NULL,
	estado varchar(50) NOT NULL,
	dvh int NOT NULL
)
;

CREATE TABLE rPedidoPlato ( 
	id_pedidoplato int NOT NULL,
	id_pedido int NOT NULL,
	id_plato int NOT NULL,
	estado varchar(50) NOT NULL,
	dvh int NOT NULL
)
;

CREATE TABLE bPedido ( 
	id_pedido int NOT NULL,
	descripcion varchar(50) NOT NULL,
	estado varchar(1) NOT NULL,
	fecha_alta date NOT NULL,
	id_usuario int NOT NULL
)
;

CREATE TABLE bBebida ( 
	id_bebida int NOT NULL,
	descripcion_corta varchar(32) NOT NULL,
	descripcion_larga varchar(200) NOT NULL,
	habilitado varchar(1) NOT NULL,
	fecha_baja date,
	id_usuario int NOT NULL,
	dvh int,
	fecha_modif date
)
;

CREATE TABLE bPlato ( 
	id_plato int NOT NULL,
	descripcion_corta varchar(32) NOT NULL,
	descripcion_larga varchar(200) NOT NULL,
	habilitado varchar(1) NOT NULL,
	fecha_baja date,
	id_usuario int NOT NULL,
	dvh int,
	fecha_modif date
)
;


ALTER TABLE rPedidoBebida ADD CONSTRAINT PK_rPedidoBebida 
	PRIMARY KEY CLUSTERED (id_pedidobebida)
;

ALTER TABLE rPedidoPlato ADD CONSTRAINT PK_rPedidoPlato 
	PRIMARY KEY CLUSTERED (id_pedidoplato)
;

ALTER TABLE bPedido ADD CONSTRAINT PK_bPedido 
	PRIMARY KEY CLUSTERED (id_pedido)
;

ALTER TABLE bBebida ADD CONSTRAINT PK_bBebida 
	PRIMARY KEY CLUSTERED (id_bebida)
; 

ALTER TABLE bPlato ADD CONSTRAINT PK_bPlato 
	PRIMARY KEY CLUSTERED (id_plato)
;


ALTER TABLE rPedidoBebida
	ADD CONSTRAINT UQ_rPedidoBebida_id_pedidobebida UNIQUE (id_pedidobebida)
;

ALTER TABLE rPedidoPlato
	ADD CONSTRAINT UQ_rPedidoPlato_id_pedidoplato UNIQUE (id_pedidoplato)
;

ALTER TABLE bBebida
	ADD CONSTRAINT UQ_bBebida_descripcion_corta UNIQUE (descripcion_corta)
;

ALTER TABLE bPlato
	ADD CONSTRAINT UQ_bPlato_descripcion_corta UNIQUE (descripcion_corta)
;
CREATE TABLE bTraductor ( 
	id_idioma int NOT NULL,
	mensaje varchar(200) NOT NULL , 
	traduccion varchar(200)
)
;

CREATE TABLE bDigitoVerificadorVertical ( 
	id_dvv int NOT NULL,
	tabla varchar(50),
	valor int
)
;

CREATE TABLE bBackup ( 
	id_backup int NOT NULL,
	descripcion varchar(300) NOT NULL,
	ruta varchar(50) NOT NULL,
	fecha datetime NOT NULL,
	id_usuario_alta int NOT NULL,
	cant_volumen int NOT NULL
)
;

CREATE TABLE bBitacora ( 
	id_bitacora int NOT NULL,
	id_usuario int NOT NULL,
	descripcion_larga varchar(100),
	fecha datetime,
	dvh int NOT NULL,
	m_error varchar(1) NOT NULL
)
;

CREATE TABLE rFamiliaPatente ( 
	id_familia int NOT NULL,
	id_patente int NOT NULL,
	m_negada varchar(1) NOT NULL,
	id_usuario_alta int  ,
	dvh int
)
;

CREATE TABLE rUsuarioFamilia ( 
	id_usuario int NOT NULL,
	id_familia int NOT NULL,
	id_usuario_alta int,
	dvh int NOT NULL
)
;

CREATE TABLE bFamilia ( 
	id_familia int NOT NULL,
	descripcion_corta varchar(100),
	descripcion_larga varchar(500),
	dvh int NOT NULL,
	id_usuario_alta int,
	fecha_baja date,
	fecha_modif date
)
;

CREATE TABLE rUsuarioPatente ( 
	id_usuario int NOT NULL,
	id_patente int NOT NULL,
	m_negada varchar(1) NOT NULL,
	id_usuario_alta int  ,
	dvh int NOT NULL
)
;

CREATE TABLE bPatente ( 
	id_patente int NOT NULL,
	descripcion_corta varchar(50),
	descripcion_larga varchar(500),
	dvh int NOT NULL,
	id_usuario_alta int,
	fecha_baja date,
	fecha_modif date
)
;

CREATE TABLE bIdioma ( 
	id_idioma int NOT NULL,
	descripcion varchar(50) NOT NULL,
	fecha_baja date
)
;

CREATE TABLE bUsuario ( 
	id_usuario int NOT NULL,
	usuario varchar(32) NOT NULL,
	contraseña varchar(32),
	nombre varchar(50) NOT NULL,
	apellido varchar(50),
	dni int NOT NULL,
	email varchar(50) NOT NULL,
	id_idioma int NOT NULL,
	fecha_nacimiento date,
	fecha_baja date,
	dvh int NOT NULL,
	intentos_login int,
	fecha_modif date,
	id_usuario_alta int
)
;


ALTER TABLE bTraductor ADD CONSTRAINT PK_bTraductor 
	PRIMARY KEY CLUSTERED (id_idioma, mensaje)
;

ALTER TABLE bDigitoVerificadorVertical ADD CONSTRAINT PK_bDigitoVerificadorVertical 
	PRIMARY KEY CLUSTERED (id_dvv)
;

ALTER TABLE bBackup ADD CONSTRAINT PK_bBackup 
	PRIMARY KEY CLUSTERED (id_backup)
;

ALTER TABLE bBitacora ADD CONSTRAINT PK_bBitacora 
	PRIMARY KEY CLUSTERED (id_bitacora)
;

ALTER TABLE rFamiliaPatente ADD CONSTRAINT PK_rFamiliaPatente 
	PRIMARY KEY CLUSTERED (id_familia, id_patente)
;

ALTER TABLE rUsuarioFamilia ADD CONSTRAINT PK_rUsuarioFamilia 
	PRIMARY KEY CLUSTERED (id_usuario, id_familia)
;

ALTER TABLE bFamilia ADD CONSTRAINT PK_bFamilia 
	PRIMARY KEY CLUSTERED (id_familia)
;

ALTER TABLE rUsuarioPatente ADD CONSTRAINT PK_rUsuarioPatente 
	PRIMARY KEY CLUSTERED (id_patente, id_usuario)
;

ALTER TABLE bPatente ADD CONSTRAINT PK_bPatente 
	PRIMARY KEY CLUSTERED (id_patente)
;

ALTER TABLE bIdioma ADD CONSTRAINT PK_bIdioma 
	PRIMARY KEY CLUSTERED (id_idioma)
;

ALTER TABLE bUsuario ADD CONSTRAINT PK_busuario 
	PRIMARY KEY CLUSTERED (id_usuario)
;


ALTER TABLE bDigitoVerificadorVertical
	ADD CONSTRAINT UQ_bDigitoVerificadorVertical_tabla UNIQUE (tabla)
;

ALTER TABLE bFamilia
	ADD CONSTRAINT UQ_bFamilia_descripcion_corta UNIQUE (descripcion_corta)
;

ALTER TABLE bPatente
	ADD CONSTRAINT UQ_bPatente_descripcion_corta UNIQUE (descripcion_larga)
;

ALTER TABLE bUsuario
	ADD CONSTRAINT UQ_busuario_dni UNIQUE (dni)
;

ALTER TABLE bUsuario
	ADD CONSTRAINT UQ_busuario_email UNIQUE (email)
;
