--get ConnectionString
select
    'data source=' + @@servername +
    ';initial catalog=' + db_name() +
    case type_desc
        when 'WINDOWS_LOGIN' 
            then ';trusted_connection=true'
        else
            ';user id=' + suser_name() + ';password=<<YourPassword>>'
    end
    as ConnectionString
from sys.server_principals
where name = suser_name();

/*
● Crear una vista que determine los 3 pacientes que pagaron en concepto de estudios y que
poseían cobertura a través de una obra social. Proyecte el nombre, el apellido, la obra social, el
plan y el importe abonado por el usuario.
*/
use Hospital;

ALTER VIEW [v_PacientesEstudiosConOS]
AS
SELECT 
	pa.nombre, 
	pa.apellido, 
	os.razonSocial obrasocial, 
	pl.sigla descplan, 
	ei.precio importe
FROM estudiosRealizados er
inner join pacientes pa on pa.dni = er.dni
inner join obraSocial os on os.sigla = er.sigla
inner join pacientes_Planes pp on pp.dni = pa.dni
inner join planes pl on pl.idPlan = pp.idPlan
inner join estudios_Institutos ei on ei.idEstudio = er.idEstudio
inner join institutos i on i.idInstituto = er.idInstituto and ei.idInstituto = i.idInstituto
;

select * from [v_PacientesEstudiosConOS];

ALTER PROCEDURE sp_PacientesEstudiosConOS
AS
SELECT 
	nombre Nombre, 
	apellido Apellido, 
	obrasocial [Obra Social], 
	descplan [Plan], 
	importe Importe
FROM [v_PacientesEstudiosConOS]
GO;

EXECUTE sp_PacientesEstudiosConOS;

ALTER PROCEDURE sp_TopPacientesViejosPorApellido
	@MaxQ integer, 
	@Pattern nvarchar(11) = null
AS
SELECT TOP (@MaxQ) 
	dni DNI,
	fechaNac [Fecha Nacimiento],
	nombre Nombre,
	apellido Apellido
FROM pacientes p
WHERE (@Pattern is NULL) or (p.apellido like @Pattern)
ORDER BY fechaNac ASC
GO;

--test
EXECUTE sp_TopPacientesViejosPorApellido @MaxQ = 5;
EXECUTE sp_TopPacientesViejosPorApellido @MaxQ = 5, @Pattern = 'g%';
EXECUTE sp_TopPacientesViejosPorApellido @MaxQ = 5, @Pattern = '%ez';
EXECUTE sp_TopPacientesViejosPorApellido @MaxQ = 5, @Pattern = '%n';

-- ????????????  no encuentro tablas ??
/*
● Crear un procedimiento para ingresar estudios programados.
○ INPUT: nombre del estudio, DNI del paciente, matrícula del médico, nombre del
instituto, sigla de la obra social, entero que inserte la cantidad de estudios a realizarse,
entero que indique el lapso en días en que debe repetirse.
○ Generar todas las tuplas necesarias en la tabla historias. (Ejemplo: control de presión
cada 48hs durante 10 días).
*/

/*
● Crear un procedimiento que devuelva la cantidad de pacientes y médicos que efectuaron
estudios en un determinado período.
○ INPUT / OUTPUT: dos enteros.
○ Ingresar período a consultar (mes y año)
○ Retornar cantidad de pacientes que se realizaron uno o más estudios y cantidad de
médicos solicitantes de los mismos, en dos variables
*/

ALTER PROCEDURE sp_CantidadPeriodoEstudiosPactesyMedicos
	@Month integer,
	@Year integer
AS
	DECLARE @temp TABLE
	(
		countMedicos INT,
		countPacientes INT
	);
	--Insert
	INSERT INTO @temp (countMedicos,countPacientes)
	VALUES
	(
		(SELECT COUNT(matricula) FROM 
		(
			SELECT matricula 
			FROM [estudiosRealizados] er 
			WHERE @Month = month(er.fecha) and 
					@Year = year(er.fecha) group by matricula
		) as cMeds),
		(SELECT COUNT(dni) FROM 
		(
			SELECT dni 
			FROM [estudiosRealizados] er 
			WHERE @Month = month(er.fecha) and 
					@Year = year(er.fecha) group by dni
		) as cPctes)
	);
	--Select temp
	SELECT
		ISNULL(countMedicos,0) [Cantidad Médicos],
		ISNULL(countPacientes,0) [Cantidad Pacientes]
	FROM @temp;

GO;

--test
EXECUTE sp_CantidadPeriodoEstudiosPactesyMedicos @Month = 5, @Year = 2013;
EXECUTE sp_CantidadPeriodoEstudiosPactesyMedicos @Month = 1, @Year = 2013;

/*
● Crear un procedimiento para ingresar el precio de un estudio.
○ INPUT: nombre del estudio, nombre del instituto y precio.
○ Si ya existe la tupla en Precios debe actualizarla.
○ Si no existe debe crearla.
○ Si no existen el estudio o el instituto debe crearlos.*/



/*
● Crear un procedimiento que devuelva el precio total a facturar y la cantidad de estudios
intervinientes a una determinada obra social.
○ INPUT: nombre de la obra social, periodo a liquidar.
○ OUTPUT: precio neto, cantidad de estudios.
○ Devuelve en dos variables el neto a facturar a la obra social o prepaga y la cantidad de
estudios que abarca para un determinado período*/