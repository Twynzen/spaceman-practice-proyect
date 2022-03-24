# NOTAS DE UNITY
## FOLDERS ASSETS
Los proyectos normalmente tienen assets como:
* -Animations
* -Audio
* -Fonts
* -Sprites
* -Scenes
* -Prefabs

## GAME SCENE SIZE
Lo ideal para el desarrollo son pantallas de 16:9

## PLAYMODE COLOR
Es ideal modificar el tinte del "playmode" para diferenciar cuando se esta probando el juego o editando.
Para modificarlo se debe: 
> UnityPreferences => Colors => Playmode tint.

## SPRITEATLAS 2D SPRITES
SpriteAtlas una gran herramienta para no usar imagenes sueltas, se extrae de un png con todas
las imagenes que se volveran sprites. (Para juegos 2D)
1. Cambiar sprite mode a multiple.
2. Se selecciona el botón **Sprite Editor**.
3. En "Slice" se tienen ciertos parametros:
* Type: Para decidir el corte de la imagen será  automatico o manual (Validar cortes correctos de cada uno).
* **Pivot:** Para definir el punto del cual posicionamos el objeto 
(normalmente en el centro para que coincida con el punto de gravedad).
* **Method:** Se entiende que se deja "delete existing" para borrar repetidos
4. Darle un nombre a cada una de las imagenes o conjunto de imagenes que generan una animación.

## COLOR SPECTRUM / GAMA DE COLORES

Lo idea es dentro de los assets tener predefinidos los colores del videojuego.

## ANIMATIONS 
1. Se selecciona el conjunto de sprites y se suelta dentro de la escena
2. Se bautiza la animación y se guarda en el asset de animaciones
3. Se generan 2 archivos por cada animación:
* **Controlador:** define condiciones para que se ejecute la animación, se divide en NODOS.
Debe haber 1 controlador por cada elemento que tenga diferentes animaciones que apliquen a este.

* **Animaciones:** Son en sí el conjunto de imagenes que unidos generan un movimiento especifico, cada una de las animaciones crearía un nodo donde se reproduciría dentro del controlador.

## TRANSSITIONS
1. La comunicación entre nodos que cambia segun los parametros o condiciones predichas apra cada animación.

## TAGS
Las etiquetas permiten tener localizados los objetos en escena por familia

## PHYSICS
> Edit => Project Settings => Physics

X Horizontal
Y Vertical (Por defecto -9.81 la gravedad de la tierra)
Para que el objeto sea afectado por las leyes de la fisica necesita tener un componente riggidbody

## RIGGIDBODY
* **Dinamico:** Se ven afectados por las fuerzas (como la gravedad)
* **Cinematico/kynematic:** No se ve afectado por fuerzas pero se mueve
* **Estatico:** No se mueve
* **Masa:** la expresión de materia del cuerpo
* **Arrastre/drag angular:** Fricción con el aire al girar, define la velocidad de giro al rebotar un objeto.
* **Arrastre/drag lineal:** Fricción con el suelo despues de llevar cierta velocidad.
* **Gravity scale:** Afectación de la gravedad.

## COLLIDER
Colicionador o forma de interactuar con los otros objetos o entornos.
Existen diferentes tipos de colliders:
* **Elementos solidos del juego**: Elementos como paredes o suelo que colisionan con el jugador
* **Zonas:** Normalmente tienen un trigger o disparador que se ejecuta cuando se toca esta zona. Los triggers se disparan normalmente con el metodo OnTrigger: 

> * **OnTriggerEnter2D():** Se utiliza para detectar si algo entra en la zona.
> * **OnTriggerStay2D():** Se detecta un constante contacto con algo que entra en la zona.
> * **OnTriggerExit2D():** Se detecta que algo salio de la zona


## LAYERS/CAPAS
Se pueden crear capas para identificar un concepto como **suelo/ground** 

## GIZMOS
Es una herramienta de debuggin visual para identificar distancias o detalles invisibles

## GAMEMANAGER 
Se crea dentro de unity para controlar el estado del juego 

## INPUTMANAGER
Para acceder al input manager esta en 
> Edit => project settings => InputManager 

Vienen diferentes configuraciones de acciones editables
Lo idea es utilizar el input manager en vez de utilizar el llamado de tecla en si

## INVOKE
Metodo valioso  es como el setInterval de Javascript retraza una ejecución un tiempo definidio.
Recibe 2 parametros:
1. El nombre de la función en un string.
2. El tiempo que durara el intervalor de tiempo.












