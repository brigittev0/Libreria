DROP DATABASE IF EXISTS libreria_cf;
CREATE DATABASE libreria_cf;

USE libreria_cf;

CREATE TABLE autores(
  autor_id INT PRIMARY KEY,
  nombre VARCHAR(25) NOT NULL,
  apellido VARCHAR(25) NOT NULL,
  seudonimo VARCHAR(50) UNIQUE,
  fecha_nacimiento DATE NOT NULL,
  pais_origen VARCHAR(40) NOT NULL,
  fecha_creacion DATETIME DEFAULT current_timestamp
);

CREATE TABLE libros(
  libro_id INTEGER PRIMARY KEY,
  autor_id INT NOT NULL,
  titulo varchar(50) NOT NULL,
  descripcion varchar(250) NOT NULL DEFAULT '',
  paginas INTEGER NOT NULL DEFAULT 0,
  fecha_publicacion Date NOT NUll,
  fecha_creacion DATETIME DEFAULT CURRENT_TIMESTAMP,
  FOREIGN KEY (autor_id) REFERENCES autores(autor_id)
);

INSERT INTO autores (autor_id, nombre, apellido, seudonimo, fecha_nacimiento, pais_origen)
VALUES (1, 'John', 'Doe', 'JD', '1990-05-15', 'Estados Unidos');

INSERT INTO autores (autor_id, nombre, apellido, seudonimo, fecha_nacimiento, pais_origen)
VALUES (2, 'Jane', 'Smith', 'JS', '1985-08-22', 'Reino Unido');

INSERT INTO autores (autor_id, nombre, apellido, fecha_nacimiento, pais_origen)
VALUES (3, 'Juan', 'Pérez', '1967-12-03', 'España');

INSERT INTO autores (autor_id, nombre, apellido, seudonimo, fecha_nacimiento, pais_origen)
VALUES (4, 'María', 'Gómez', NULL, '1995-02-10', 'Argentina');

-------------------------------------------------------------------------------------------------------
INSERT INTO libros (libro_id, autor_id, titulo, descripcion, paginas, fecha_publicacion)
VALUES (1, 1, 'El Gran Libro', 'Una historia emocionante', 200, '2022-10-15');

INSERT INTO libros (libro_id, autor_id, titulo, descripcion, paginas, fecha_publicacion)
VALUES (2, 2, 'Aventuras en el Bosque', 'Un cuento mágico', 50, '2023-01-20');

INSERT INTO libros (libro_id, autor_id, titulo, descripcion, paginas, fecha_publicacion)
VALUES (3, 1, 'El Secreto Oculto', 'Un misterio por resolver', 150, '2023-05-05');

INSERT INTO libros (libro_id, autor_id, titulo, paginas, fecha_publicacion)
VALUES (4, 3, 'Viaje al Pasado', 100, '2023-02-12');



SELECT * FROM libros;
SELECT * FROM autores;
