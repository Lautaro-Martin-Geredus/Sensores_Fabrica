# Aplicacion de Sensores de una Fabrica

Esta aplicacion Desarrollada en 5 lenguajes diferentes: SQL Server, C#, HTML, CSS Y JavaScript nos permite realizar el mantenimiento de unos sensores de temperatura ubicados estrategicamente en las distintas areas de una fabrica ficticia.

Esta app cuenta con un algoritmo de logueo el cual valida si el usuario esta creado en la base de datos o no, si sus credenciales coinciden puede acceder al sistema, en caso que no la aplicacion lanzara un error de datos incorrectos.

Luego de ingresar al sistema se podra, como se menciono anteriormente, realizar un mantenimiento de los sensores, para esto se desarrollo un CRUD para la entidad Sensores que nos permite crearlos, obtenerlos, modificarlos y eliminarlos.

Una vez realizado dicho mantenimiento hacia los sensores a gusto del usuario, podra consultar las lecturas de los sensores atraves de un algoritmo de fechas, se ingresan 2 fechas en un rango para determinar la busqueda de la lectura de dicho sensor, tambien
la aplicacion es capaz de generar una lectura hacia un sensor ingresando su nombre y automaticamente se generara con una temperatura.
