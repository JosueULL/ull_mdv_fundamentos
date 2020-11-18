# Eventos

![alt text](https://github.com/JosueULL/ull_mdv_fundamentos/blob/master/entrega10/events.gif)

Para la realización de la práctica se han utilizado los mismos assets de la práctica anterior.

Algunos requerimientos de la práctica se han ajustado para encajar mejor con el prototipo que se está desarrollando.

## UI

En este prototipo se ha añadido sencillamente un botón de reinicio de nivel. Al pulsar el botón, sencillamente se recarga el nivel usando el GameController, restaurando todo a su estado inicial. 
Para esto se han usado el evento de UI OnClick disponible en el componente Button.

![alt text](https://github.com/JosueULL/ull_mdv_fundamentos/blob/master/entrega10/restart.PNG)
![alt text](https://github.com/JosueULL/ull_mdv_fundamentos/blob/master/entrega10/events2.gif)

## Interacción

Se ha creado un componente llamado TriggerListener que lanza un evento en OnTriggerEnter usando un UnityEvent. 

Utilizar un UnityEvent del sistema de eventos de Unity nos da la oportunidad de definir lo que ocurre al accionarse el evento en el inspector de Unity como pasa con los eventos de UI.

Con una configuración apropiada de capas físicas, aseguramos que esto puede ser únicamente accionado por el jugador. En nuestro caso, hemos creado la capa OnlyCollidesWithPlayer y asignado esta capa a los objetos que el jugador puede accionar.

## Dos objetos que responden de forma diferente

Para demostrar el requerimiento de múltiples objetos reaccionando a un evento, hemos posicionado una placa en el suelo del nivel que al ser pulsada accionará la aparición y desaparición de pinchos en el nivel.

![alt text](https://github.com/JosueULL/ull_mdv_fundamentos/blob/master/entrega10/button.PNG)

Unos objetos bajan y otros suben dependiendo de lo que tengan configurado en su componente TweenPosition (explicado más adelante). Pero podemos asignar un número arbitrario de reacciones al evento usando el inspector de gracias al Drawer que Unity nos proporciona para los objetos de tipo UnityEvent.

![alt text](https://github.com/JosueULL/ull_mdv_fundamentos/blob/master/entrega10/buttonevent.PNG)

## Objeto que desplaza barreras

Se ha creado una barrera infranqueable en un lateral del nivel que únicamente puede pasarse si se activa la palanca.

![alt text](https://github.com/JosueULL/ull_mdv_fundamentos/blob/master/entrega10/lever.PNG)

Para esta palanca se ha usado el mismo sistema de interacción que para la placa/botón. Al accionar la palanca, se cambia el sprite, se anima la barrera y adicionalmente se desactiva el collider para que no se vuelva a accionar.

![alt text](https://github.com/JosueULL/ull_mdv_fundamentos/blob/master/entrega10/leverevent.PNG)

Esto podría facilmente convertirse en un coleccionable si desactivamos el objeto. En este caso era más interesante utilizar una palanca.

## Movmiento de objetos

Adicionalmente, para esta práctica se ha implementado un componente que permite animar la posición de un objeto. Este componente anima la posición de forma lineal basándose en un offfset durante una duración estipulada y se ha utilizado para todos los elementos del ejercicio excepto para la palanca.

![alt text](https://github.com/JosueULL/ull_mdv_fundamentos/blob/master/entrega10/spikes.PNG)
![alt text](https://github.com/JosueULL/ull_mdv_fundamentos/blob/master/entrega10/tween.PNG)

