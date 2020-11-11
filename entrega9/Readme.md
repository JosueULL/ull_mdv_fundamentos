# Generación de Tilemaps

![alt text](https://github.com/JosueULL/ull_mdv_fundamentos/blob/master/entrega9/tilemap.gif)

## Assets

Para la realización de la práctica se han utilizado los siguientes tilemaps gratuitos:

https://opengameart.org/content/isometric-64x64-medieval-building-tileset

https://blackspirestudio.itch.io/medieval-pixel-art-asset-free

## Paletas

Se ha procedido a la creación de las paletas tanto normal como isométrica.

Para la paleta isométrica se ha decidido (trás probar varios tamaños de celda) dejar un margen en los tiles para permitir verlos correctamente y configurar el tamaño del tile en el Grid para pegar los tiles los unos a los otros.

![alt text](https://github.com/JosueULL/ull_mdv_fundamentos/blob/master/entrega9/palette1.PNG)
![alt text](https://github.com/JosueULL/ull_mdv_fundamentos/blob/master/entrega9/paletteISO.PNG)

## Mapa convencional

Se ha creado el siguiente nivel utilizando la paleta y los componentes y prefabs utilizados en prácticas anteriores.

![alt text](https://github.com/JosueULL/ull_mdv_fundamentos/blob/master/entrega9/tilemap.PNG)

Para las colisiones del nivel se ha utilizado un CompositeCollider2D junto con TilemapCollider2D para obtener un movimiento más fluido con el personaje, que por ahora usa un BoxCollider2D.

## Mapa isométrico

Se ha creado el siguiente nivel isométrico utilizando la paleta

![alt text](https://github.com/JosueULL/ull_mdv_fundamentos/blob/master/entrega9/mapISO.PNG)

Para crear las diferentes alturas del nivel se han creado varios tilemaps con diferente orden de capa, usando un valor más alto para los niveles superiores.

![alt text](https://github.com/JosueULL/ull_mdv_fundamentos/blob/master/entrega9/mapISOh.PNG)
