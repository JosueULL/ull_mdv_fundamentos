# Cinemachine

En esta práctica hemos realizado un prototipo que se ajusta a los siguientes requerimientos
- Cámara con seguimiento al personaje A. Se debe configurar el seguimiento hacia adelante. Esta cámara es la que debe tener la máxima prioridad.
- Cámara con seguimiento al personaje B. Debe configurarse una zona de seguimiento del personaje B más amplia que la de A.
- Cámara que hace el seguimiento de ambos personajes.
- Crear una zona de confinamiento de A que abarque toda la escena.
- Se debe crear una zona de confinamiento de la cámara B que abarque una parte de la escena.
- Añadir un objeto que genere una vibración en la cámara cuando A choca con el
- Seleccionar un conjunto de teclas que permitan hacer el cambio de la cámara de los personajes a la cámara que sigue al grupo. (Habilitar/Deshabilitar el gameobject de la cámara virtual)
- Generar una vibración en la cámara cada vez que se pulse la tecla de disparo. Agregar un perfil de ruido a la cámara, y modificar las propiedades de amplitud y frecuencia al component Noise

![alt text](https://github.com/JosueULL/ull_mdv_fundamentos/blob/master/entrega12/game.gif)

Para la realización de la práctica se han utilizado los assets facilitados por la profesora para la prueba evaluatoria.

## Personajes

Se han creado dos personajes que responden a los mismos inputs pero colisionan independientemente con el escenario.

## Camaras

Se han creado 3 cámaras : 
- Una camara persigue al personaje 1 y esta restringida al area definida por las tumbas grises
- Una camara persigue al personaje 2 y esta restringida al area definida por las tumbas violetas
- Una camara que persigue a ambos jugadores y se adapta dependiendo de la distancia entre ambos

![alt text](https://github.com/JosueULL/ull_mdv_fundamentos/blob/master/entrega12/cameras.png)

Para cambiar las cámaras por conveniencia se ha creado una UI con varios botones que permiten la facil interacción del usuario.

Al pulsar el botón solo la cámara requerida se mantiene activa.

![alt text](https://github.com/JosueULL/ull_mdv_fundamentos/blob/master/entrega12/ui.png)

## Impulsos

Se han configurado dos impulsos que usan el mismo perfil.

![alt text](https://github.com/JosueULL/ull_mdv_fundamentos/blob/master/entrega12/impulse.png)

Uno se ejecuta cuando el jugador colisiona con un arbusto. Para ello se ha utilizado el componente CinemachineCollisionInputSource.

![alt text](https://github.com/JosueULL/ull_mdv_fundamentos/blob/master/entrega12/bush.png)

Adicionalmente se ha creado otro impulso usando el componente CinemachineImpulseSource. Ese impulso se ejecuta manualmente desde el botón de la UI.

