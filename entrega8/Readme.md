# Introducción a la programación de juegos 2D. Físicas

En esta práctica se ha realizado un estudio sobre las distintas interacciones físicas en Unity y una pequeña escena siguiendo las siguientes directrices
* Objeto estático que ejerce de barrera infranqueable.
* Zona en la que los objetos que caen en ella son impulsados hacia adelante.
* Objeto que es arrastrado por otro a una distancia fija.
* Objeto que al colisionar con otros sigue un comportamiento totalmente físico.
* Incluye dos capas que asignes a diferentes tipos de objetos y que permita evitar colisiones entre ellos.

## Interacciones físicas en Unity

### Dos objetos no físicos

Si solapamos dos objetos no físicos, donde cada uno tiene un collider, no se recibirá ningún evento ni habrá ninguna interacción entre ellos.

### Objeto físico vs Objeto no físico

Al agregar un component Rigidbody a uno de los objetos, éste se verá afectado inmediatamente por la gravedad. Si reducimos la escala de la gravedad a 0 para apreciar la interacción entre los objetos, veremos que el objeto físico es impulsado hacia un lateral para evitar el solapamiento.

Ambos objetos reciben el evento OnCollisionEnter.

Los objetos siguen estando en contacto tras el desplazamiento y por lo tanto no se recibe el evento OnCollisionExit. Si desplazamos manualmente el objeto veremos que este evento es adecuadamente comunicado a los objetos.

### Dos objetos físicos

Al solapar dos objetos físicos (con gravedad desactivada) apreciamos que ambos se desplazan igualmente para evitar el solapamiento.

Al igual que en el ejemplo anterior. Ambos objetos reciben el evento OnCollisionEnter y los objetos siguen estando en contacto tras el desplazamiento y por lo tanto no se recibe el evento OnCollisionExit.

### Dos objetos físicos (Uno con x10 de masa)

Al cambiar la masa de uno de los objetos físicos por 10 en comparación al otro su desplazamiento fue mucho menor a la hora de evitar el solapamiento. Es otras palabras, el objeto ofreció una resistencia mayor al desplazamiento.

Al igual que en el ejemplo anterior. Ambos objetos reciben el evento OnCollisionEnter y los objetos siguen estando en contacto tras el desplazamiento y por lo tanto no se recibe el evento OnCollisionExit.

### Objeto físico vs Trigger

Ninguno de los objetos realizó desplazamiento alguno y ambos objetos recibieron el evento OnTriggerEnter.

### Dos objetos físicos (Uno es Trigger)

Se obtuvo el mismo resultado que en el ejemplo anterior. Pero en este caso, si activamos la gravedad, ambos objetos se verán afectador por ella.

### Dos objetos físicos (Uno es Cinemático)

Se obtuvo el mismo resultado que en Físico vs No Físico. Aunque es recomendable usar este tipo de configuración para cuando el objeto no físico tiene movimiento (una plataforma móvil, por ejemplo). Al realizar el movimiento a través del Rigidbody se estará realizando durante la simulación física y en un intervalo constante por lo que podrán detectarse colisiones correctamente.

La siguiente documentación contiene más información sobre las distintas interacciones físicas entre colliders en Unity y ofrece dos matrices bastante útiles con información sobre la recepción de eventos físicos. Aunque se trata de la documentación para colliders 3D, mucho de los conceptos aplican a los colliders en 2D.

https://docs.unity3d.com/Manual/CollidersOverview.html

## Objetos

### Personaje

El movimiento del personaje se ha modificado para utilizar su componente de Rigidbody. Se ha utilizado Raycasting a ambos lados del collider para determinar si el personaje esta o no afianzado al suelo (Grounded). También se podría haber usado un collider y controlar el solapamiento o colisiones con la escena.

### Limite de escena (Objeto estático que ejerce de barrera infranqueable.)

Se han añadido colliders estáticos a los bordes de la pantalla para que ni el jugador ni los objetos se salgan de la escena.

### Viento (Zona en la que los objetos que caen en ella son impulsados hacia adelante.)

Se ha añadido una zona de viento en la escena que impulsa los objetos en una dirección. Para ello se ha usado el componente AreaEffector que impulsa los objetos que entran en el BoxCollider adjunto al objeto.

![alt text](https://github.com/JosueULL/ull_mdv_fundamentos/blob/master/entrega8/wind.gif)

### Mini Slime (Objeto que es arrastrado por otro a una distancia fija)

Se ha utilizado el componente DistanceJoint2D que permite conectar dos Rigidbodies respetando una distancia. En este caso, el Mini Slime (enemigo) persige al slime por la escena

![alt text](https://github.com/JosueULL/ull_mdv_fundamentos/blob/master/entrega8/slime.gif)

## Cajas (Objeto que al colisionar con otros sigue un comportamiento totalmente físico)

Las cajas se han configurado como Rigidbodies dinámicos que son afectados por la gravedad.

![alt text](https://github.com/JosueULL/ull_mdv_fundamentos/blob/master/entrega8/boxes.gif)

## Capas físicas (Incluye dos capas que asignes a diferentes tipos de objetos y que permita evitar colisiones entre ellos.)

Se han configurado 3 capas Player, Enemy y Breakable. De forma que el Player y Enemy no colisionan pero los dos colisionan con Brekable (objetos rompibles).

![alt text](https://github.com/JosueULL/ull_mdv_fundamentos/blob/master/entrega8/layers.gif)
