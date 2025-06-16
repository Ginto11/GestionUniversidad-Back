USE GestionUniversidad;
GO

--SELECT * FROM  sys.Tables;


--PROCEDIMIENTO E INSERCIONES
CREATE PROCEDURE crearEstadoMateria(
	 @nombre VARCHAR(20)
) AS 
BEGIN
	INSERT INTO estado_materia(nombre_estado) VALUES(@nombre);
END
GO


EXEC crearEstadoMateria 'Activa';
EXEC crearEstadoMateria 'Inactiva';
GO

CREATE PROCEDURE crearRol(
	@nombre_rol VARCHAR(20)
) AS 
BEGIN
	INSERT INTO roles(nombre_rol) VALUES(@nombre_rol);
END
GO

EXEC crearRol 'Administrador';
EXEC crearRol 'Estudiante';
EXEC crearRol 'Docente';
GO


CREATE PROCEDURE crearEstadoMatricula(
	@nombre VARCHAR(20)
) AS
BEGIN
	INSERT INTO estado_matricula(nombre_estado) VALUES(@nombre);
END
GO

EXEC crearEstadoMatricula 'Activa';
EXEC crearEstadoMatricula 'Cancelada';
EXEC crearEstadoMatricula 'Finalizada';
EXEC crearEstadoMatricula 'Creando';
GO

CREATE PROCEDURE crearFacultad(
	@nombre VARCHAR(100),
	@descripcion TEXT)
AS
BEGIN
	INSERT INTO facultades(nombre, descripcion) VALUES (@nombre, @descripcion);
END

GO

EXEC dbo.crearFacultad 
    @nombre = 'Facultad de Ingeniería', 
    @descripcion = 'Enfocada en programas relacionados con ingeniería de sistemas, civil, industrial, electrónica, entre otros.';

EXEC dbo.crearFacultad 
    @nombre = 'Facultad de Ciencias Económicas y Administrativas', 
    @descripcion = 'Incluye programas como administración de empresas, contaduría, economía y finanzas.';

EXEC dbo.crearFacultad 
    @nombre = 'Facultad de Ciencias de la Salud', 
    @descripcion = 'Ofrece carreras relacionadas con medicina, enfermería, fisioterapia y otras áreas de la salud.';

EXEC dbo.crearFacultad 
    @nombre = 'Facultad de Humanidades y Ciencias Sociales', 
    @descripcion = 'Programas enfocados en sociología, psicología, trabajo social, historia, filosofía, entre otros.';

EXEC dbo.crearFacultad 
    @nombre = 'Facultad de Ciencias Básicas', 
    @descripcion = 'Incluye carreras como matemáticas, física, química y biología.';

EXEC dbo.crearFacultad 
    @nombre = 'Facultad de Artes', 
    @descripcion = 'Programas académicos en música, teatro, danza, artes visuales y diseño.';

EXEC dbo.crearFacultad 
    @nombre = 'Facultad de Derecho y Ciencias Políticas', 
    @descripcion = 'Carreras relacionadas con derecho, ciencias políticas y relaciones internacionales.';

EXEC dbo.crearFacultad 
    @nombre = 'Facultad de Educación', 
    @descripcion = 'Formación para futuros docentes en distintas áreas del conocimiento.';

EXEC dbo.crearFacultad 
    @nombre = 'Facultad de Arquitectura y Diseño', 
    @descripcion = 'Incluye programas como arquitectura, diseño industrial, diseño gráfico y urbanismo.';
GO

CREATE PROCEDURE crearGenero(
	@genero VARCHAR(20)
) AS
BEGIN
	INSERT INTO generos(nombre_genero) VALUES(@genero);
END
GO

EXEC crearGenero 'Masculino';
EXEC crearGenero 'Femenino';
EXEC crearGenero 'Otro';
GO

CREATE PROCEDURE crearPrograma(
	@nombre VARCHAR(100),
	@descripcion TEXT, 
	@duracion INT,
	@id_facultad INT
)AS
BEGIN
	INSERT INTO programas(nombre, descripcion, duracion, id_facultad) VALUES(@nombre, @descripcion, @duracion, @id_facultad);
END
GO

EXEC dbo.crearPrograma 
    @nombre = 'Psicología',
    @descripcion = 'Estudio del comportamiento humano y los procesos mentales.',
    @duracion = 10,
    @id_facultad = 4;

EXEC dbo.crearPrograma 
    @nombre = 'Diseño Gráfico',
    @descripcion = 'Diseño visual de contenidos digitales e impresos.',
    @duracion = 8,
    @id_facultad = 6;

EXEC dbo.crearPrograma 
    @nombre = 'Arquitectura',
    @descripcion = 'Diseño y construcción de espacios arquitectónicos.',
    @duracion = 10,
    @id_facultad = 9;

EXEC dbo.crearPrograma 
    @nombre = 'Ingeniería de Sistemas',
    @descripcion = 'Formación en desarrollo de software, bases de datos, y sistemas informáticos.',
    @duracion = 10,
    @id_facultad = 1;

EXEC dbo.crearPrograma 
    @nombre = 'Administración de Empresas',
    @descripcion = 'Gestión de empresas y organizaciones.',
    @duracion = 8,
    @id_facultad = 2;

EXEC dbo.crearPrograma 
    @nombre = 'Licenciatura en Educación Infantil',
    @descripcion = 'Formación de docentes para la primera infancia.',
    @duracion = 8,
    @id_facultad = 8;

EXEC dbo.crearPrograma 
    @nombre = 'Medicina',
    @descripcion = 'Diagnóstico, tratamiento y prevención de enfermedades humanas.',
    @duracion = 12,
    @id_facultad = 3;

EXEC dbo.crearPrograma 
    @nombre = 'Contaduría Pública',
    @descripcion = 'Formación en contabilidad, auditoría y gestión tributaria.',
    @duracion = 8,
    @id_facultad = 2;

EXEC dbo.crearPrograma 
    @nombre = 'Ingeniería Civil',
    @descripcion = 'Diseño, construcción y supervisión de obras civiles.',
    @duracion = 10,
    @id_facultad = 1;

EXEC dbo.crearPrograma 
    @nombre = 'Derecho',
    @descripcion = 'Estudio del sistema legal, justicia, y legislación.',
    @duracion = 10,
    @id_facultad = 7;

EXEC dbo.crearPrograma 
    @nombre = 'Matemáticas',
    @descripcion = 'Formación en análisis, álgebra, estadística y modelado matemático.',
    @duracion = 8,
    @id_facultad = 5;

EXEC dbo.crearPrograma 
    @nombre = 'Enfermería',
    @descripcion = 'Atención integral al paciente y gestión del cuidado de la salud.',
    @duracion = 8,
    @id_facultad = 3;
GO

CREATE PROCEDURE crearDocente(
	@cedula INT, 
	@nombre VARCHAR(50),
	@apellido VARCHAR(50), 
	@edad INT,
	@id_genero INT,
	@email VARCHAR(100),
	@contrasena VARCHAR(200),
	@id_rol INT = 3
)AS
BEGIN
	BEGIN TRY
		IF EXISTS (SELECT 1 FROM docentes WHERE email = @email)
		BEGIN
			RAISERROR('El email ya está registrado. %s', 16, 1, @email);
		END
		
		INSERT INTO docentes(cedula, nombre, apellido, edad, id_genero, email, contrasena, id_rol) 
		VALUES(@cedula, @nombre, @apellido, @edad, @id_genero, @email, @contrasena, @id_rol);
	END TRY
	BEGIN CATCH
		THROW;
	END CATCH
END
GO

EXEC dbo.crearDocente 
	1001944317, 
	'Nelson', 
	'Muñoz', 
	23, 
	1, 
	'nelson.administrador@gestionuniversidad.com', 
	'UsPN3lexcl9LyHlIHuw6ew==',
	1;

EXEC dbo.crearDocente 
    @cedula = 1205987531, 
    @nombre = 'Carlos', 
    @apellido = 'Gómez', 
    @edad = 45, 
    @id_genero = 1, 
    @email = 'carlos.gomez@gmail.com', 
    @contrasena = 'CarlosGómez45';

EXEC dbo.crearDocente 
    @cedula = 1139845620, 
    @nombre = 'Ana', 
    @apellido = 'López', 
    @edad = 32, 
    @id_genero = 2, 
    @email = 'ana.lopez@email.com', 
    @contrasena = 'AnaLópez32';

EXEC dbo.crearDocente 
    @cedula = 1287654312, 
    @nombre = 'Pedro', 
    @apellido = 'Martínez', 
    @edad = 38, 
    @id_genero = 1, 
    @email = 'pedro.martinez@gmail.com', 
    @contrasena = 'PedroMartínez38';

EXEC dbo.crearDocente 
    @cedula = 1345678923, 
    @nombre = 'María', 
    @apellido = 'García', 
    @edad = 41, 
    @id_genero = 2, 
    @email = 'maria.garcia@gmail.com', 
    @contrasena = 'MaríaGarcía41';

EXEC dbo.crearDocente 
    @cedula = 1567894321, 
    @nombre = 'José', 
    @apellido = 'Hernández', 
    @edad = 50, 
    @id_genero = 1, 
    @email = 'jose.hernandez@gmail.com', 
    @contrasena = 'JoséHernández50';

EXEC dbo.crearDocente 
    @cedula = 1402386952, 
    @nombre = 'Isabel', 
    @apellido = 'Pérez', 
    @edad = 30, 
    @id_genero = 2, 
    @email = 'isabel.perez@gmail.com', 
    @contrasena = 'IsabelPérez30';

EXEC dbo.crearDocente 
    @cedula = 1556348924, 
    @nombre = 'Luis', 
    @apellido = 'Díaz', 
    @edad = 40, 
    @id_genero = 1, 
    @email = 'luis.diaz@gmail.com', 
    @contrasena = 'LuisDíaz40';

EXEC dbo.crearDocente 
    @cedula = 1658943271, 
    @nombre = 'Sofía', 
    @apellido = 'Vargas', 
    @edad = 29, 
    @id_genero = 2, 
    @email = 'sofia.vargas@gmail.com', 
    @contrasena = 'SofíaVargas29';

EXEC dbo.crearDocente 
    @cedula = 1987452312, 
    @nombre = 'Ricardo', 
    @apellido = 'Torres', 
    @edad = 35, 
    @id_genero = 1, 
    @email = 'ricardo.torres@gmail.com', 
    @contrasena = 'RicardoTorres35';

EXEC dbo.crearDocente 
    @cedula = 1209837456, 
    @nombre = 'Carmen', 
    @apellido = 'Ramírez', 
    @edad = 36, 
    @id_genero = 2, 
    @email = 'carmen.ramirez@gmail.com', 
    @contrasena = 'CarmenRamírez36';

EXEC dbo.crearDocente 
    @cedula = 1489736201, 
    @nombre = 'Javier', 
    @apellido = 'Gutiérrez', 
    @edad = 55, 
    @id_genero = 1, 
    @email = 'javier.gutierrez@gmail.com', 
    @contrasena = 'JavierGutiérrez55';

EXEC dbo.crearDocente 
    @cedula = 1302945879, 
    @nombre = 'Laura', 
    @apellido = 'Martínez', 
    @edad = 29, 
    @id_genero = 2, 
    @email = 'laura.martinez@email.com', 
    @contrasena = 'LauraMartínez29';

EXEC dbo.crearDocente 
    @cedula = 1435269841, 
    @nombre = 'Antonio', 
    @apellido = 'Hernández', 
    @edad = 48, 
    @id_genero = 1, 
    @email = 'antonio.hernandez@gmail.com', 
    @contrasena = 'AntonioHernández48';

EXEC dbo.crearDocente 
    @cedula = 1563287456, 
    @nombre = 'Patricia', 
    @apellido = 'Sánchez', 
    @edad = 41, 
    @id_genero = 2, 
    @email = 'patricia.sanchez@gmail.com', 
    @contrasena = 'PatriciaSánchez41';

EXEC dbo.crearDocente 
    @cedula = 1612375489, 
    @nombre = 'David', 
    @apellido = 'López', 
    @edad = 50, 
    @id_genero = 1, 
    @email = 'david.lopez@gmail.com', 
    @contrasena = 'DavidLópez50';

EXEC dbo.crearDocente 
    @cedula = 1759286340, 
    @nombre = 'Elena', 
    @apellido = 'Castro', 
    @edad = 31, 
    @id_genero = 2, 
    @email = 'elena.castro@gmail.com', 
    @contrasena = 'ElenaCastro31';

EXEC dbo.crearDocente 
    @cedula = 1892347651, 
    @nombre = 'Francisco', 
    @apellido = 'Ramírez', 
    @edad = 49, 
    @id_genero = 1, 
    @email = 'francisco.ramirez@gmail.com', 
    @contrasena = 'FranciscoRamírez49';

EXEC dbo.crearDocente 
    @cedula = 1228736549, 
    @nombre = 'Marta', 
    @apellido = 'Alonso', 
    @edad = 42, 
    @id_genero = 2, 
    @email = 'marta.alonso@gmail.com', 
    @contrasena = 'MartaAlonso42';

EXEC dbo.crearDocente 
    @cedula = 1986543210, 
    @nombre = 'Sergio', 
    @apellido = 'González', 
    @edad = 33, 
    @id_genero = 1, 
    @email = 'sergio.gonzalez@gmail.com', 
    @contrasena = 'SergioGonzález33';

EXEC dbo.crearDocente 
    @cedula = 1635849072, 
    @nombre = 'Vera', 
    @apellido = 'Mendoza', 
    @edad = 39, 
    @id_genero = 3, 
    @email = 'vera.mendoza@gmail.com', 
    @contrasena = 'VeraMendoza39';
GO

CREATE PROCEDURE crearEstudiante(
	@cedula INT, 
	@nombre VARCHAR(50),
	@apellido VARCHAR(50),
	@edad INT, 
	@id_genero INT,
	@email VARCHAR(100),
	@contrasena VARCHAR(100),
	@id_rol INT = 2
) AS
BEGIN
	BEGIN TRY
		IF EXISTS (SELECT 1 FROM estudiantes WHERE email = @email)
		BEGIN
			RAISERROR('El email (%s) ya está registrado.', 16, 1, @email);
		END
		INSERT INTO estudiantes(cedula, nombre, apellido, edad, id_genero, email, contrasena, id_rol)
		VALUES(@cedula, @nombre, @apellido, @edad, @id_genero, @email, @contrasena, @id_rol);
	END TRY
	BEGIN CATCH
		THROW;
	END CATCH
END
GO


EXEC crearEstudiante 1001944317, 'Nelson', 'Muñoz', 23, 1, 'nelson.administrador@gestionuniversidad.com', 'UsPN3lexcl9LyHlIHuw6ew==', 1;
EXEC crearEstudiante 1234567890, 'Carlos', 'Ramirez', 20, 1, 'carlos20@gmail.com', 'Carlos20';
EXEC crearEstudiante 1234567891, 'Laura', 'Mendoza', 22, 2, 'laura22@gmail.com', 'Laura22';
EXEC crearEstudiante 1234567892, 'Diego', 'Martinez', 19, 1, 'diego19@gmail.com', 'Diego19';
EXEC crearEstudiante 1234567893, 'Sofia', 'Perez', 23, 2, 'sofia23@gmail.com', 'Sofia23';
EXEC crearEstudiante 1234567894, 'Andres', 'Gomez', 21, 1, 'andres21@gmail.com', 'Andres21';
EXEC crearEstudiante 1234567895, 'Valeria', 'Lopez', 20, 2, 'valeria20@gmail.com', 'Valeria20';
EXEC crearEstudiante 1234567896, 'Luis', 'Fernandez', 24, 1, 'luis24@gmail.com', 'Luis24';
EXEC crearEstudiante 1234567897, 'Camila', 'Rios', 22, 2, 'camila22@gmail.com', 'Camila22';
EXEC crearEstudiante 1234567898, 'Mateo', 'Vargas', 23, 1, 'mateo23@gmail.com', 'Mateo23';
EXEC crearEstudiante 1234567899, 'Mariana', 'Silva', 21, 2, 'mariana21@gmail.com', 'Mariana21';
EXEC crearEstudiante 1234567900, 'Sebastian', 'Torres', 25, 1, 'sebastian25@gmail.com', 'Sebastian25';
EXEC crearEstudiante 1234567901, 'Daniela', 'Cruz', 20, 2, 'daniela20@gmail.com', 'Daniela20';
EXEC crearEstudiante 1234567902, 'Jorge', 'Ortiz', 19, 1, 'jorge19@gmail.com', 'Jorge19';
EXEC crearEstudiante 1234567903, 'Isabella', 'Morales', 22, 2, 'isabella22@gmail.com', 'Isabella22';
EXEC crearEstudiante 1234567904, 'Gabriel', 'Castro', 24, 1, 'gabriel24@gmail.com', 'Gabriel24';
EXEC crearEstudiante 1234567905, 'Ana', 'Navarro', 20, 2, 'ana20@gmail.com', 'Ana20';
EXEC crearEstudiante 1234567906, 'Ricardo', 'Santos', 21, 1, 'ricardo21@gmail.com', 'Ricardo21';
EXEC crearEstudiante 1234567907, 'Lucia', 'Herrera', 23, 2, 'lucia23@gmail.com', 'Lucia23';
EXEC crearEstudiante 1234567908, 'Martin', 'Delgado', 22, 1, 'martin22@gmail.com', 'Martin22';
EXEC crearEstudiante 1234567909, 'Paula', 'Acosta', 19, 2, 'paula19@gmail.com', 'Paula19';
GO

CREATE PROCEDURE crearMateria(
	@nombre VARCHAR(200),
	@creditos INT, 
	@valor_credito DECIMAL(10, 2),
	@modalidad VARCHAR(30),
	@descripcion VARCHAR(800),
	@id_docente INT, 
	@id_programa INT
) AS
BEGIN
	DECLARE @costo_calculado DECIMAL(10, 2) = @creditos * @valor_credito;
	DECLARE @horas_estudio INT = @creditos * 48;

	INSERT INTO materias(nombre, horas_estudio, creditos, valor_credito, costo_total, modalidad, descripcion, id_estado_materia, id_docente, id_programa)
	VALUES (@nombre, @horas_estudio, @creditos, @valor_credito, @costo_calculado, @modalidad, @descripcion, 1, @id_docente, @id_programa);
END
GO

EXEC dbo.crearMateria @nombre = 'Psicología Básica', @creditos = 4, @valor_credito = 100000, @modalidad = 'Presencial', @descripcion = 'Introducción a la psicología y el estudio del comportamiento humano.', @id_docente = 1, @id_programa = 1;
EXEC dbo.crearMateria @nombre = 'Diseño Visual', @creditos = 6, @valor_credito = 120000, @modalidad = 'Presencial', @descripcion = 'Fundamentos de diseño visual digital e impreso.', @id_docente = 2, @id_programa = 2;
EXEC dbo.crearMateria @nombre = 'Teoría del Diseño Arquitectónico', @creditos = 4, @valor_credito = 130000, @modalidad = 'Presencial', @descripcion = 'Teoría sobre la creación y diseño de espacios arquitectónicos.', @id_docente = 3, @id_programa = 3;
EXEC dbo.crearMateria @nombre = 'Desarrollo de Software', @creditos = 4, @valor_credito = 110000, @modalidad = 'Virtual', @descripcion = 'Fundamentos del desarrollo de software y programación.', @id_docente = 4, @id_programa = 4;
EXEC dbo.crearMateria @nombre = 'Gestión de Proyectos Empresariales', @creditos = 3, @valor_credito = 95000, @modalidad = 'Presencial', @descripcion = 'Gestión eficiente de proyectos en una empresa.', @id_docente = 5, @id_programa = 5;
EXEC dbo.crearMateria @nombre = 'Educación Infantil I', @creditos = 4, @valor_credito = 105000, @modalidad = 'Presencial', @descripcion = 'Técnicas y estrategias de enseñanza para la primera infancia.', @id_docente = 6, @id_programa = 6;
EXEC dbo.crearMateria @nombre = 'Medicina General', @creditos = 6, @valor_credito = 150000, @modalidad = 'Presencial', @descripcion = 'Conceptos generales de medicina y prácticas de diagnóstico.', @id_docente = 7, @id_programa = 7;
EXEC dbo.crearMateria @nombre = 'Contabilidad I', @creditos = 3, @valor_credito = 95000, @modalidad = 'Virtual', @descripcion = 'Fundamentos de contabilidad, incluyendo balance general y cuentas.', @id_docente = 8, @id_programa = 8;
EXEC dbo.crearMateria @nombre = 'Cálculo Diferencial en Ingeniería', @creditos = 4, @valor_credito = 120000, @modalidad = 'Presencial', @descripcion = 'Estudio de las aplicaciones de Cálculo Diferencial en ingeniería civil.', @id_docente = 9, @id_programa = 9;
EXEC dbo.crearMateria @nombre = 'Derecho Penal', @creditos = 4, @valor_credito = 115000, @modalidad = 'Presencial', @descripcion = 'Estudio de las leyes y procesos del derecho penal.', @id_docente = 2, @id_programa = 10;
EXEC dbo.crearMateria @nombre = 'Matemáticas Aplicadas', @creditos = 3, @valor_credito = 105000, @modalidad = 'Virtual', @descripcion = 'Aplicación de conceptos matemáticos en el mundo real y en la investigación.', @id_docente = 11, @id_programa = 11;
EXEC dbo.crearMateria @nombre = 'Cuidado de Pacientes Críticos', @creditos = 4, @valor_credito = 120000, @modalidad = 'Presencial', @descripcion = 'Técnicas de atención y cuidado a pacientes en situaciones críticas.', @id_docente = 12, @id_programa = 7;
EXEC dbo.crearMateria @nombre = 'Psicología Educativa', @creditos = 4, @valor_credito = 110000, @modalidad = 'Presencial', @descripcion = 'Aplicación de conceptos psicológicos en el contexto educativo.', @id_docente = 1, @id_programa = 1;
EXEC dbo.crearMateria @nombre = 'Diseño Gráfico Digital', @creditos = 6, @valor_credito = 125000, @modalidad = 'Presencial', @descripcion = 'Diseño y creación de contenido gráfico digital, incluidos sitios web y publicidad.', @id_docente = 2, @id_programa = 2;
EXEC dbo.crearMateria @nombre = 'Construcción de Obras', @creditos = 5, @valor_credito = 135000, @modalidad = 'Presencial', @descripcion = 'Proceso de construcción y gestión de proyectos arquitectónicos y civiles.', @id_docente = 3, @id_programa = 3;
EXEC dbo.crearMateria @nombre = 'Redes de Computadoras', @creditos = 4, @valor_credito = 115000, @modalidad = 'Virtual', @descripcion = 'Fundamentos de redes y sistemas distribuidos para la conectividad de computadoras.', @id_docente = 4, @id_programa = 4;
EXEC dbo.crearMateria @nombre = 'Estrategias Financieras', @creditos = 3, @valor_credito = 100000, @modalidad = 'Presencial', @descripcion = 'Estrategias para la optimización y gestión de recursos financieros en las empresas.', @id_docente = 5, @id_programa = 5;
EXEC dbo.crearMateria @nombre = 'Psicología Infantil', @creditos = 4, @valor_credito = 110000, @modalidad = 'Presencial', @descripcion = 'Estudio del desarrollo psicológico en la primera infancia y sus trastornos.', @id_docente = 6, @id_programa = 6;
EXEC dbo.crearMateria @nombre = 'Medicina Preventiva', @creditos = 5, @valor_credito = 140000, @modalidad = 'Presencial', @descripcion = 'Estudio de métodos preventivos en salud y diagnóstico temprano de enfermedades.', @id_docente = 7, @id_programa = 7;
GO

CREATE PROCEDURE actualizarMateria(
	@id_materia INT, 
	@nombre VARCHAR(200),
	@creditos INT, 
	@valor_credito DECIMAL(10, 2),
	@modalidad VARCHAR(30),
	@descripcion VARCHAR(800),
	@id_estado_materia INT,
	@id_docente INT, 
	@id_programa INT
) AS 
BEGIN 
	DECLARE @costo_calculado DECIMAL(10, 2) = @creditos * @valor_credito;
	DECLARE @horas_estudio INT = @creditos * 48;

	UPDATE materias SET 
		nombre = @nombre,
		creditos = @creditos,
		valor_credito = @valor_credito,
		modalidad = @modalidad,
		costo_total = @costo_calculado,
		horas_estudio = @horas_estudio,
		descripcion = @descripcion,
		id_estado_materia = @id_estado_materia,
		id_docente = @id_docente,
		id_programa = @id_programa
	WHERE id_materia = @id_materia;

END
GO



CREATE PROCEDURE listarDocentes 
AS
BEGIN
	SELECT 
		docentes.id_docente AS id_docente,
		docentes.cedula,
		docentes.nombre, 
		docentes.apellido,
		docentes.edad,
		generos.nombre_genero AS genero,
		docentes.email,
		roles.nombre_rol AS rol
	FROM docentes
	JOIN generos ON docentes.id_genero = generos.id_genero
	JOIN roles ON docentes.id_rol = roles.id_rol;
END
GO

CREATE PROCEDURE buscarDocente(
	@email VARCHAR(100),
	@contrasena VARCHAR(100)
) AS 
BEGIN
	BEGIN TRY
		
		IF NOT EXISTS (SELECT 1  FROM docentes WHERE email = @email AND contrasena = @contrasena)
		BEGIN
			RAISERROR('Credenciales incorrectas.', 16, 1);
		END

		SELECT 
			docentes.id_docente AS id,
			docentes.cedula,
			docentes.nombre,
			docentes.apellido,
			docentes.edad,
			docentes.email,
			generos.nombre_genero AS genero,
			roles.nombre_rol AS rol
		FROM docentes 
		JOIN generos ON docentes.id_genero = generos.id_genero
		JOIN roles ON docentes.id_rol = roles.id_rol
		WHERE email = @email AND contrasena = @contrasena

	END TRY
	BEGIN CATCH
		THROW;
	END CATCH
END
GO


CREATE PROCEDURE generandoMatricula(
	@id_estudiante INT
) AS
BEGIN

	DECLARE @semestreAnterior INT;
	DECLARE @semestreActual INT;

	IF NOT EXISTS (SELECT 1 FROM matriculas WHERE id_estudiante = @id_estudiante AND estado_matricula = 3)
	BEGIN
		INSERT INTO matriculas(id_estudiante, semestre, estado_matricula)
			VALUES(@id_estudiante, 1, 4);
			SELECT * FROM matriculas WHERE id_estudiante = @id_estudiante AND estado_matricula = 4;
			RETURN;
	END

	IF EXISTS (SELECT 1 FROM matriculas WHERE id_estudiante = @id_estudiante AND estado_matricula = 3)
	BEGIN
		SET @semestreAnterior = (SELECT MAX(semestre) FROM matriculas WHERE id_estudiante = @id_estudiante AND estado_matricula = 3);
		SET @semestreActual = @semestreAnterior + 1;

		IF @semestreAnterior <= 10 
		BEGIN 
			INSERT INTO matriculas(id_estudiante, semestre, estado_matricula)
				VALUES(@id_estudiante, @semestreActual, 4);
				SELECT * FROM matriculas WHERE id_estudiante = @id_estudiante AND estado_matricula = 4;
				RETURN;
		END
	END

END
GO


CREATE PROCEDURE inscripcionMateria(
	@id_materia INT,
	@id_matricula INT
) AS 
BEGIN
	DECLARE @costo_incripcion DECIMAL(10, 2);

	IF NOT EXISTS (SELECT 1 FROM materias WHERE id_materia = @id_materia)
	BEGIN
		RAISERROR('Recurso Nº %d no encontrado.', 16, 1, @id_materia);
		RETURN;
	END

	SET @costo_incripcion = (SELECT costo_total FROM materias WHERE id_materia = @id_materia);

	INSERT INTO inscribir_materia(id_materia, id_matricula, costo_inscripcion) VALUES(@id_materia, @id_matricula, @costo_incripcion);

END
GO


CREATE PROCEDURE finalizarIncripcion(
	@id_matricula INT
) AS
BEGIN
	DECLARE @costo_total_matricula DECIMAL(10, 2);

	SET @costo_total_matricula = (SELECT SUM(costo_inscripcion) FROM inscribir_materia WHERE id_matricula = @id_matricula);

	UPDATE matriculas SET costo_matricula = @costo_total_matricula, estado_matricula = 1 WHERE id_matricula = @id_matricula;
END
GO

CREATE PROCEDURE pagarMatricula(
	@id_matricula INT
)AS
BEGIN
	IF EXISTS (SELECT 1 FROM matriculas WHERE estado_matricula = 1 AND esta_paga = 0 AND id_matricula = @id_matricula)
	BEGIN
		UPDATE matriculas SET esta_paga = 1 WHERE id_matricula = @id_matricula;
		RETURN;
	END
	RAISERROR('Recurso Nº %d no encontrado.', 16, 1, @id_matricula);
END
GO


/*
    INSERCION DE RUTAS
    UPDATE programas SET ruta_imagen = 'psicologia.jpg' WHERE id_programa = 1;
    UPDATE programas SET ruta_imagen = 'diseño-grafico.jpg' WHERE id_programa = 2;
    UPDATE programas SET ruta_imagen = 'arquitectura.jpg' WHERE id_programa = 3;
    UPDATE programas SET ruta_imagen = 'ingenieria-sistemas.jpg' WHERE id_programa = 4;
    UPDATE programas SET ruta_imagen = 'administracion-empresas.jpg' WHERE id_programa = 5;
    UPDATE programas SET ruta_imagen = 'educacion-infantil.jpg' WHERE id_programa = 6;
    UPDATE programas SET ruta_imagen = 'medicina.jpg' WHERE id_programa = 7;
    UPDATE programas SET ruta_imagen = 'contaduria.jpg' WHERE id_programa = 8;
    UPDATE programas SET ruta_imagen = 'ingenieria-civil.jpg' WHERE id_programa = 9;
    UPDATE programas SET ruta_imagen = 'derecho.jpeg' WHERE id_programa = 10;
    UPDATE programas SET ruta_imagen = 'matematicas.png' WHERE id_programa = 11;
    UPDATE programas SET ruta_imagen = 'enfermeria.jpg' WHERE id_programa = 12;


*/

--CREATE PROCEDURE cancelarMatricula()

/*
SELECT * FROM estado_matricula;
SELECT * FROM matriculas;
SELECT * FROM roles;
SELECT * FROM docentes;
SELECT * FROM estado_materia;
SELECT * FROM estudiantes;
SELECT * FROM facultades;
SELECT * FROM generos;	
SELECT * FROM inscribir_materia;
SELECT * FROM materias;
SELECT * FROM programas;
*/





