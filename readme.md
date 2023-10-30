Imagine que está trabajando en un proyecto de seguimiento de errores. Tienes tres entidades: Proyecto, Error, Usuario. El modelo se describe de la siguiente manera: 
Usuario: 
• Id - user identifier 
• Name - user first name 
• Surname - user surname 
Bug: 
• Id - bug identifier 
• projectId - project identifier 
• User - related user 
• Description - text summary of the bug (maximum 100 characters) 
• CreationDate 
Project: 
• Id - project identifier 
• Name - project name 
• Description - a brief description of the project (optional) 
Además, tenga en cuenta que un Proyecto tiene Errores y el Error está asignado a un Usuario. Cree un proyecto WebApi desde cero para gestionar la asignación de errores. 
TAREAS: 
• Configurar el sistema para utilizar una base de datos de SQL Server llamada BugsManager. Inicializar base de datos con 5 usuarios y 5 proyectos. 
• Implementar BugController para gestionar operaciones relacionadas con errores (CRUD) con los siguientes supuestos: a. Implemente un punto final para asignar un error a un usuario. Este punto final debe enrutarse como POST /bug y recibirá la siguiente carga útil { “user”: integer (required), “project”: integer (required), “description”: string (required) } Asígnele un error a un usuario b. Implemente un punto final para devolver todos los errores de un usuario, proyecto, rango de fechas o todos los parámetros determinados. Dígame los errores de un usuario Manejará una solicitud GET de la siguiente forma: /bugs?project_id=<project-id>&user_id=<user-id> &start_date=<start_date>&end_date=<end_date>, where: • se requiere al menos un parámetro; • sólo se permite el método GET; de lo contrario, se devuelve un código de estado 405; • si no se encontraron errores en las condiciones del filtro, se devuelve un código de estado 404; • De lo contrario, deberá devolver un código de estado 200 y una respuesta en el siguiente formato JSON: { "bugs": [ { 
"id": <bug-id>, "description": <bug-description>, "username": <assigned-username>, "project": <related-project>, “CreationDate”: <creationDate> } ] } • Implementar, con .net, en un proyecto diferente, pantallas adecuadas para soportar la asignación de errores según los métodos de API web implementados. o Panel de control de todos los errores. Con filtrado por usuario, proyecto y rango de fechas de creación o Crear un nuevo error para un proyecto y asignarlo a un usuario existente. Ejemplos Llamar a POST /bugs?project_id=1 devolverá un código de estado 405. Llamar a GET /bugs?project_id=9999 (asumiendo que no tenemos un proyecto con id = 9999) devolverá un código de estado 404. Llamar a GET /bugs?user_id=9999 (asumiendo que no tenemos un usuario con id = 9999) devolverá un código de estado 404. Llamar a GET /bugs?project_id=1 (asumiendo que tenemos un proyecto con id = 1) devolverá un código de estado 200 y la siguiente respuesta: { "bugs": [ { "id": 1, "description": "bug 1 description", "username": "username 1", "project": "project 1" }, { "id": 3, "description": "bug 3 description", "username": "username 2", "project": "project 1" } ] } Llamar a GET /bugs?project_id=1&user_id=2 (asumiendo que tenemos un proyecto con id = 1 y un usuario con id = 2) devolverá un código de estado 200 y la siguiente respuesta: { "bugs": [ { "id": 3, "description": "bug 3 description", "username": "username 2", "project": "project 1", “CreationDate”: “dd/MM/yyyy hh:mm:ss” } ] } 