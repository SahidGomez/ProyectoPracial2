# ProyectoPracial2
Este es un proyecto del parcial2 de PPV2
Este es un compendio de las clases vistas en la materia de Programación para Videojuegos 2.
Proyecto basado en la aplicación de duolingo, el Build 1 contiene la interfaz que dependiendo el boton es la leccion que reproducira.
esto hecho con listas de string junto con clases para que la informacion aparezca en la Interfaz de usuario 
El segundo Build (en la carpeta llamada Lesson1) contiene preguntas sobre progrmación con listas y ScriptableObject los cuales contienen la informacion de las preguntas, ocupamos un boton para validar si la pregunta es correcta o incorrecta, si la respuesta es correcta en la interfaz de usario aparecera un cuadro verde con la leyenda "Respuesta Correcta" de lo contrario si la respuesta es incorrecta el texto que aparecera sera "Respuesta Incorrecta", todo esto cambiando entre cada pregunta con un tiempo establecido en el codigo.

Parcial3
---
El tercer ejecutable se encuentra en la carpeta EjecutableParcial3
Video y capturas de como es el juego se encuentran en EjecutableParcial3 / Capturas

SCRIPS
---
LessonContainer: Supervisa la leccion que esta en la interfaz
LevelManager: Agarra los datos de scriptableobject para hacer las preguntas y asi como comprobar si esta bien o mal
Options: se encarga de establecer las opciones, su id y el texto de la opcion
SaveSystem: Carga archivos de tipo Json el cual se encargara de cargar las preguntas en la interfaz
MainScript: Recibe el nombre de la leccion. Tambien cambia la escena, para que del menu se pueda dirigir a la escena de la leccion seleccionada
Creditos: Este sirve para que cambie de la escena de lesson a la de creditos

JUEGO
---
Menu: Contiene las diferente lecciones que puedes elegir 
Lecciones: 5 tipos de lecciones las cuales contienen diferentes preguntas

JUGABILIDAD
---
Cuando inicies el juego aparecera las diferentes lecciones las cuales puedes elegir 
Al seleccionar una este te mandara a la leccion junto con sus preguntas y tendras que responderlas
Si estas mal, se mostrara en la interfaz un recuadro rojo y la leyenda de "Respuesta Incorrecta" y a su vez la respuesta correcta
Si la tienes correcta solo se mostrara un recuadro verde y la leyenda "Respuesta Correcta" y continuara a la siguiente pregunta
![Captura de pantalla 2024-04-15 173838](https://github.com/SahidGomez/ProyectoPracial2/assets/156129783/76c59c2f-8d2d-4e1d-9bc0-cdbd62adec7c)
![Captura de pantalla 2024-04-15 173930](https://github.com/SahidGomez/ProyectoPracial2/assets/156129783/1ac2dda1-cc3a-4b32-9473-98faf05b6bbe)
![Captura de pantalla 2024-04-15 174026](https://github.com/SahidGomez/ProyectoPracial2/assets/156129783/7cdbad87-4404-4872-a2ed-05aaf648234e)
![Captura de pantalla 2024-04-15 174305](https://github.com/SahidGomez/ProyectoPracial2/assets/156129783/3c90e0f0-55db-440d-bf46-eff421f468b6)
![Captura de pantalla 2024-04-15 174348](https://github.com/SahidGomez/ProyectoPracial2/assets/156129783/69033dae-4dd3-4713-ac65-d8bf7a0a9eb7)
![Captura de pantalla 2024-04-15 174439](https://github.com/SahidGomez/ProyectoPracial2/assets/156129783/f377ada5-553b-4742-8fbd-f9f936739e0e)


Para poder Instalar el ejecutable desde GitHub puedes clonar el repositorio o darle click donde dice "Code" y darle en DownloadZip
