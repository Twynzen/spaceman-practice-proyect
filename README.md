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

## SINGLETON
Importante patron de diseño que permite no volver a repetir una instancia de clase. Especifico para que solo haya un controlador. Se aplica normalmente a:
* **GameManager:** Solo se necesita un manejador del juego.
* **PlayerControler:** Para casos de 1 solo jugador.
* **LevelManager:** Solo se necesita un controlador de todos los niveles.
El singleton se utiliza así dentro del Awake:
```cs
public static CosoManager sharedInstance;

    void Awake(){
        if(sharedInstance == null){
            sharedInstance = this;
        }
    }
```

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

## MAP/LEVEL-DESING 2D OBJECT POOLING

<img src="https://images.pexels.com/photos/189296/pexels-photo-189296.jpeg?cs=srgb&dl=pexels-donald-tong-189296.jpg&fm=jpg" alt="drawing" style="width:200px;"/>

Es util ordenar todos los elementos de una zona como paredes y suelos dentro de un mismo objeto: este es llamado **bloque de nivel**. Al unir todas estas estructuras se logra un orden claro del escenario.
### CONTROL DE MAPAS PROCEDURALES
Una estrategía para crear escenarios procedurales es colocar unos: 
* **StartPoint:** Al inicio del bloque de nivel.
* **EndPoint:** Al final del bloque de nivel.
> Esto permitirá, una vez esten alineados, identificar un equilibrio en la ubicación de los bloques del escenario.
> El bloque de nivel debe tener un script que reciba los 2 puntos Start y End.


1. Se crea un array donde se almacenaran todos los bloques de nivel:
```cs
    public List<LevelBlock> allTheLevelBlocks = new List<LevelBlock>();
```
2. Se crea un array para los bloques de nivel actuales:
```cs
    public List<LevelBlock> currentLevelBlocks = new List<LevelBlock>();
```
3. Se crea una variable donde se crea el primer bloque:
```cs
    public Transform levelStartPosition;
```
> Este **levelStartPosition** debe crearce como GamerObject y pasarlo como parametro al **LevelManager**. También se le pasa por parametro al **AddLevelBlock** todos los bloques de nivel creados.
**Level Manager:** Lógica que permite dar control a los bloques de nivel. Esta logica tendrá 4 funciones principales:
> * **AddLevelBlock:** Para añadir nuevos bloques de nivel.
> > Se utiliza una variable generadora de números random, con la limitación de bloques de niveles que queremos adiccionar.
```cs
    int random = Random.Range(0, allTheLevelBlocks.Count);
```
> > Se debe usar la logica de los bloques que deseamos añadir cumpla la expectativa, en caso de que se quiera que el bloque inicial en ejemplo sea unico, se puede colocar una condición que permita instanciar el primer bloque solo una vez. 

> > Se instancias los bloques de esta forma
```cs
    block = Intantiate(allTheLevelBlocks[random]);
```

> * **RemoveLevelBlock:** Para borrar un bloque de nivel que ya no este en uso.
> * **RemoveAllLevelBlocks:** Para borarr todos los bloques de nivel.
> * **GenerateInitialBlocks:** Para generar nuevos bloques iniciales. Tendrá un bucle que llamara al **AddLevelBlock** las veces que sean necesarias. El **GenerateInitialBlocks** se inicializará dentro del Start();

**Exit Zone:** Destruirá el bloque anterior de la visualización. Será un objeto con un colider extendido verticalmente que cubra y sobrepase el tamaño de altura de la camara.
* Debe tener el "is Trigger" activado. En el codigo se utilizaría:
```cs
    void onTriggerEnter2D(Collider2D collision){

    }
```
* Debe tener un script para manejar su funcionalidad.

#### TIPS 
* Para juegos 2d (normalmente de plataformas) es bueno tener un entorno plano para comenzar.

## RAGDOLL
Un ragdoll no es más que un conjunto de objetos 2d o 3d unidos entre sí. Este tenrá efecto de las leyes de la fisica y podrá tener diferentes tamaños, formas y movimientos.
> > * Se puede colocar un suelo para que funcione de plataforma.
1. El ragdoll estaría compuesto por objetos 2d o 3d estos deben tener:
> * **RigidBody:** Para que le afecten las leyes de la física.
> * **BoxCollider:** Para que colicionen las partes del ragdoll con el entorno.
2. Se deben distribuir los objetos que componen al ragdoll con extremidades y algún torso. Estas extrmidades deben poder conectarse al torso con el componente:
> * **HingeJoint:** Este tendrá un parametro llamado **Connected Rigid Body** el cual debe recibir a si mismo otro parametro el cual sería el torso o extremidad de donde se compacte al cuerpo.










