# Prueba-tecnica-Midway

API Web .net7

Para poder probar la API, hacer un git-clone. En un principio están subidos todos los archivos necesarios. No debería ser necesario descargar e instalar nada.
# 1. Descargar .net7
Descargamos la versión x64 de .net7 del siguiente enlace https://dotnet.microsoft.com/es-es/download.
# 2. Hacer un git clone del repo.
git clone https://github.com/josekbm/Prueba-tecnica-Midway
# 3. Iniciar la API.
instalar las extensiones de Visual Studio Code que fuesen necesarias (C#, .net Runtime Install tool)
Abrir la terminal dentro de VSC (ctrl ñ), navigar hasta la carpeta **APIMidway** e introducir el comando **dotnet run**. La api se iniciará en http://localhost:5282
# 4. Comprobar funcionalidad.
Utilizando Postman o ThunderClient hacemos una petición POST a **http://localhost:5282/usuario/login** introduciendo en el body de la petición en formato .json la siguiente información:

  {
    "UPN":"usuario1@midwaytest.tech",
    "password":"admin"
  }
Esta petición generará como respuesta un token, que deberemos copiar para poner como método de autenticación "Bearer" si queremos hacer peticiones GET, POST, PUT o DELETE. La API obtiene la información de una base de datos en SQLite.
Hasta aquí llegaría la comprobación de la API. Podemos dejarla arrancada en ese puerto y continuar con el front-end de React que consume la API en https://github.com/josekbm/Frontend-Midway
