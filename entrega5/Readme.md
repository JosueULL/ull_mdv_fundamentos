
# Proyecto Unity3D con Perforce 

En primer lugar nos conectamos o creamos un nuevo servidor Perforce usando HelixClient. En este caso hemos optado por iniciar un servidor local en la misma carpeta donde estaba nuestro proyecto Unity localizado

![alt text](https://github.com/JosueULL/ull_mdv_fundamentos/blob/master/entrega5/screen1.png)

Una vez creado, los ficheros existentes de añaden al servidor como estado inicial y podemos verlos en nuestro Workspace.

![alt text](https://github.com/JosueULL/ull_mdv_fundamentos/blob/master/entrega5/screen2.png)

Los nuevos cambios aparecerán en la pestaña de Pending. Para subir nuevos cambios a nuestro servidor, creamos una nueva Changelist a la que añadiremos los ficheros modificados.

![alt text](https://github.com/JosueULL/ull_mdv_fundamentos/blob/master/entrega5/screen3.png)

Pulsaremos el botón Submit para comittear nuestros cambios.

El botón Get Latest obtendrá los cambios añadidos al server por otros usuarios.

Refresh, actualizará nuestro workspace, añadiendo a nuestra lista de Pending los nuevos ficheros modificados.
