# RestRoomApp

RestRoomApp es una aplicación web que permite la reserva de habitaciones por períodos establecidos de tiempo. 

  - Es fácil de usar
  - Con interfaz amigable
  - ¡Es seguro!
  
### Tecnologías Utilizadas
Se ha realizado el proyecto utilizando el framework web MVC5 para `.NET` con el lenguaje de programación `C#` y Entity Framework (EF). 

### Motivación
Proyecto que se realiza como ejercicio práctico para el curso de Metodologías Ágiles para el Master de Ingeniería Web de la Universidad Politécnica de Madrid. 

### Instalar el Proyecto
Seguir el siguiente [tutorial](https://docs.microsoft.com/en-us/vsts/git/tutorial/clone?view=vsts&tabs=visual-studio)

### Subir Nuevo Código
1. Sincronizar la rama develop local con la remota (**origin/develop**):
```
   git checkout develop
   git pull origin develop
````
2. Si fuera necesario, actualizar la rama **issue** con los últimos cambios de **develop**:
```
   git checkout issue#XX
   git merge develop --no-ff
```
3. Lanzar todos los test y asegurarse que no hay errores
4. Actualizar **develop** con los nuevos cambios de mi rama (repetir los pasos **2** y **3**):
```
   git checkout develop
   git merge issue#XX --no-ff
```
5. Subir la rama **develop** al remoto: 
```
   git checkout develop
   git push origin develop
```
6. Activar la rama **issue#XX** para seguir con el desarrollo y subirla al remoto:
```
   git checkout issue#XX
   git push origin issue#XX
```

### Reinstalar Paquetes
Si se necesita recrear la carpeta **packages** ejecutar la siguiente línea de comando en la consola **NuGet**:
```
   Update-Package -reinstall
```

### Problemas con Entity Framework
En caso de tener problemas con el Entity Framework ejecutar la siguiente línea de comando en la consola **NuGet**:
```
   Install-Package EntityFramework
```

Para mas [información](https://msdn.microsoft.com/en-us/library/ee712906(v=vs.113).aspx)


### Integrantes
* **Project Owner**: Rodrigo
* **Scrum Master**: David Blas
* **Desarrolladores**:
  * Covadonga 
  * Diana
  * Carlos
  * Gabriel Muñumel

Licencia
----

MIT
