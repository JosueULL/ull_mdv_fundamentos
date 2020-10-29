
# Introducción a la programación de juegos 2D. Sprites.

En esta práctica se ha realizado una pequeña escena que se ajusta a los siguientes requerimientos:

* Obtener assets que incorpores a tu proyecto: Sprites individuales y Atlas de Sprites.
* Incorporar los recursos del punto 1 en el proyecto y generar al menos 2 animaciones para uno de los personajes.
* Busca en el inspector de objetos la propiedad Flip y comprueba qué pasa al activarla desactivarla en alguno de los ejes.
* Mover uno de los personajes con el eje horizontal virtual que definen las teclas de flechas.
* Hacer saltar el personaje y cambiar de dirección cuando se pulsa la barra espaciadora.
* Crear una animación para otro personaje, que se active cuando el jugador pulse la tecla x.
* Agregar un objeto que al estar el personaje a una distancia menor que un umbral se active una animación, por ejemplo explosión o cualquier otra que venga en el atlas de sprites.

![alt text](https://github.com/JosueULL/ull_mdv_fundamentos/blob/master/entrega7/screen2.gif)

## Assets

Se han utilizado diversos assets de uso gratuito de la web itch.io

https://itch.io/game-assets/tag-resources

## Movimiento del jugador

Para esta práctica se ha utilizado un código similar a la práctica anterior. Un único script que controla el movimiento y acciones del jugador. 

Ya que esta práctica no se centra en el uso de físicas sino en el uso de sprites, guardamos la posición Y inicial del personaje como referencia del suelo para finalizar los saltos del personaje.

En la próxima práctica, utilizaremos un collider y otras técnicas diferentes para determinar cuando el personaje ha terminado un salto o una caída (parámetro Grounded).

La clase PlayerMovement utiliza el sistema de input tradicional de Unity, obteniendo los el input para el eje horizontal y el botón de salto.

También actualizamos varios parámetros en el Animator para controlar la animación del personaje. 
 * Speed : Valor que indica lo rápido que se mueve el personaje (sin signo)
 * Jump : Trigger que hace que se reproduzca la animación de salto
 * Grounded : Bool que indica si el personaje está en el suelo
 * VerticalVel : Valor que indica la velocidad vertical del personaje (con signo)

El parámetro flipX es controlado desde el script teniendo en cuenta la velocidad horizontal.

Para el salto del personaje se ha usado una AnimationCurve (JumpAcceleration) que representa la aceleración que se aplicará al personaje a su coordenada Y durante el salto.   

Para esta práctica se ha usado el transform del personaje y no el Rigidbody para el salto y el movimiento.

## Orden de pintado

Para respetar el orden de pintado de los sprites en la perspectiva escogida para la práctica se ha seleccionado Transparency Sort Mode = Custom en las propiedades gráficas del proyecto (Edit->Project Settings->Graphics). Usando el eje {0,1,0} para ordenar automáticamente el los sprites respecto a ese eje.

En los SpriteRenderer de se ha seleccionado SpriteSortPoint = Pivot y se ha establecido el pivot en los sprites individualmente para que el sorting funcionase correctamente.

## Animación de otros personajes

Se ha implementado una animación de Idle básica para el resto de personajes que escuchan el uso de la tecla X por parte del usuario para ejecutar una animación.

![alt text](https://github.com/JosueULL/ull_mdv_fundamentos/blob/master/entrega7/screen3.gif)

## Ruptura de objetos

También se han implementado objetos rompibles que ejecutan una animación cuando el jugador colisiona con ellos. Para esto se ha utilizado colliders y un Rigidbody en el personaje por simplicidad y rendimiento. La distancia de ruptura se puede ajustar modificando el tamaño del collider. 

Podríamos haber comparado la distancia del personaje y el objeto en Update con el siguiente código:

```
void Update()
{
	if (Vector3.Distance(Player.position, transform.position) < sBreakThreshold)
	{
		mAnimator.SetTrigger(sBreakHash);	
	}
}
```

Pero esto acarrea los siguientes problemas:
 * Update es llamado por cada objeto rompible y cada frame para realizar una operación de calculo de distancia que es relativamente costosa (aunque se podría usar SqrDistance para minimizar el coste).
 * Los objetos rompibles necesitan una referencia directa al jugador.
 * Los objetos rompibles solo funcionarían con un jugador. Se necesitarían referencias a todos los personajes que pueden romperlos para que funcionase con esos personajes. Adicionalmente, tendríamos que realizar una operación de calculo de distancia por personaje, por objeto rompible, cada frame.

Por este motivo se han utilizado colliders, donde cada objeto rompible escucha OnTriggerEnter2D, momento en el que ejecuta su animación. También sería recomendable mover los objetos rompibles a su propia capa física y hacer que solo colisiones con personajes u objetos dinámicos.
