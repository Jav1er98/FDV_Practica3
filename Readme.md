## Práctica 3: C#. Programación de Scripts.
## Objetivo: Resolver los siguientes ejercicios.

1. Configurar la coordenada Y del Objetivo en 0
  - Poner al Objetivo una coordenada Y distinta de cero.
      - Hago uso de la función Vector3.MoveTowards(). Declarando un Vector3 goal, con el cual indico el objetivo (0,5,0).
      ![gif ejercicio 1](/gifs/Ejercicio1.1.gif)
      
  - Cómo modificarías el script para que el objeto despegue del suelo y vuele como un avión.
      - Modifico la trayectoria de x y z con el fin de simular el despegue de un avión.
      ![gif ejercicio 1](/gifs/Ejercicio1.2.gif)
      
2. Duplicar los valores de X, Y, Z del Objetivo. ¿Es consistente el movimiento?
  - El Objetivo no es un objetivo propiamente dicho, sino una dirección en la que queremos movernos.
  - La información relevante de un vector es la dirección. Los vectores normalizados, conservan la misma dirección pero su escala no afecta al movimiento. 
  Esto se consigue con el método normalized de la clase Vector3: this.transform.Translate(goal.normalized);
  - Con el vector normalizado, lo podemos multiplicar por un valor de velocidad para determinar cómo de rápido va el personaje. public float speed = 0.1f 
  this.transform.Translate(goal.normalized*speed)
  - A pesar de que esas velocidades puedan parecer ahora que son consistentes, no lo son, porque dependen de la velocidad a la que se produzca el update. 
  El tiempo entre dos updates no es necesariamente siempre el mismo, con lo que se pueden tener inconsistencias en la velocidad, y a pesar de que 
  en aplicaciones con poca complejidad no lo notemos, se debe usar: this.transform.Translate(goal.normalized * speed*Time.deltaTime);  para suavizar el 
  movimiento ya que Time.deltaTime es el tiempo que ha pasado desde el último frame
  
      - El cubo al iniciar el movimiento irá congestionado, el tiempo entre frames es más largo. Al normalizar el vector, el cubo se desplaza aún más rapido,
      esto es debido a que tendrá una longitud de 1, por ello se añade la variable speed de tipo float que permite controlar la velocidad a la que se mueve el cubo.
      Al añadir ambas, tendré el mismo resultado que hasta ahora, la cuestión viene por la velocidad por frame del cubo, lo que se mueve por cada frame, no puedo depender
      de los fps que tenga cada máquina. Necesito pasar de velocidad por frame a velocidad por segundo es decir "los segundos por frame" y multiplicar ese valor. Como
      se trata de un valor imprevisible, debo hacer en cada valor este mismo cálculo usando el valor que proporciona Time.deltaTime que se corresponde a la cantidad de
      segundos que han transcurrido desde el frame anterior. Con ello puedo calcular el cubo en el frame actual.
      
      ![gif ejercicio 2](/gifs/Ejercicio2.gif)
      
3. En lugar de seguir usando una dirección como objetivo, vamos a movernos ahora hacia una posición objetivo.
  - Hacemos el objetivo una variable pública public Transform goal y añadimos un public float speed = 1.0f.
  - La dirección en la que nos tenemos que mover viene determinada por la diferencia entre la posición del objetivo y nuestra posición: 
  Vector3 direction = goal.position - this.transform.position; this.transform.Translate(direction.normalized * speed * Time.deltaTime)
  
     - Al colocar una variable Transform y que necesitamos un objetivo, añado otro cubo, al primer cubo le pasaré el transfron del segundo para que se dirija hacia el,
     se dirige hasta estar dentro del propio cubo ya que no hemos puesto ningun tipo de accuracy.
     ![gif ejercicio 3](/gifs/Ejercicio3.gif)
     
4. Cuando ejecutamos el script, el personaje calcula la dirección hacia el objetivo y se mueve hacia él (lo podemos probar desde varias posiciones de inicio), 
pero no puede dejar de moverse y se produce jittering. La razón es que todavía estamos dentro del bucle, calculando la dirección y moviéndonos hacia él.
  - En la mayoría de los casos no vamos a conseguir que nuestro personaje se mueva a la posición exacta del objetivo, con lo que continuamente oscila 
  entorno a esa posición.
  - Debemos establecer un rango de tolerancia. Incluimos una variable global pública, public float accuracy = 0.01f; y una condición 
  if(direction.magnitude > accuracy). Aún con el accuracy, el personaje puede hacer jitter si la velocidad es muy alta.
  
     - Añado el umbra para evitar el efecto jittering. Mi accuracy es de 1 para que se note un poco más al tratarse de dos cubos.
     ![gif ejercicio 4](/gifs/Ejercicio4.gif)
     
5. Girar hacia el objetivo. En este caso, se dispone el método LookAt de la clase Transform. Debe girarse primero y luego avanzar.
  - this.transform.LookAt(goal.position) en el Start para que gire primero y luego se mueva.
  - Si lo ejecutamos en este momento, como la orientación del personaje va a cambiar, el translate no va a funcionar correctamente porque los ejes del  
  personaje y el mundo no están alineados. El movimiento se debe hacer de forma relativa al sistema de referencia del mundo. this.transform.Translate(direction.normalized * speed * Time.deltaTime, 
  Space.World).
  
    - Utilizo el mmetodo LookAt. Con el que se observa que primero se gira y luego avanza.
    ![gif ejercicio 5](/gifs/Ejercicio5.gif)
     
6. Añadir Debug.DrawRay(this.transform.position,direction,Color.red) para depuración para comprobar que la dirección está correctamente calculada.

    - Se debe activar el modo Gizmo, para observar la comprobación del cálculo.
    ![gif ejercicio 6](/gifs/Ejercicio6.gif)
    
7. Crear un script que haga que el personaje siga al cubo. El cubo debe ser movido usando las teclas de flechas del Starter Assets.

  - Añadimos la esfera y con lo planteado anteriormente le añadimos el código que ya teniamos solo que el transform que seguirá será el del cubo, al cubo le añado
  un script para moverse y que pueda rotar.
    ![gif ejercicio 7](/gifs/Ejercicio7.gif)
    
8. Crear una escena simple sobre la que probar diferentes configuraciones de objetos físicos en Unity. La escena debe tener un plano a modo de suelo, dos esferas y un cubo.
     - a. Ninguno de los objetos será físico.
          - Permancen inmóviles en la escena.
          ![gif ejercicio 8](/gifs/Ejercicio8a.gif)
     - b. Las esfera tiene físicas, el cubo no, pero se puede mover por el controlador en 3ª persona de los starter Assets.
          - El cubo cuando choca con ellas las desplaza, si las esferas estaban elevadas caen al suelo.
          ![gif ejercicio 8](/gifs/Ejercicio8bv2.gif)
     - c. Las esferas y el cubo tienen físicas. El cubo inicialmente está posicionado más alto que alguna de las esferas, con el mismo valor de x, z.
          -  las dos esferas caerán al suelo si estaban elevadas con respecto al mismo y el cubo caerá encima de una de las esferas y se mantendrá en
          equilibrio sobre la esfera
          ![gif ejercicio 8](/gifs/Ejercicio8cv2.gif)
     - d. Una escena similar a la c, pero alguna esfera tiene 10 veces la masa del cubo.
          - la esfera rebota.
          ![gif ejercicio 8](/gifs/Ejercicio8d.gif)
     - e. Las esferas tienen físicas y el cubo es de tipo IsTrigger estático.
          - la esfera traspasa el cubo.
          ![gif ejercicio 8](/gifs/Ejercicio8ev2.gif)   
     - f. Las esferas tienen físicas, el cubo es de tipo IsTrigger y cinemático.
          - Sucede lo mismo que el caso anterior.
          ![gif ejercicio 8](/gifs/Ejercicio8fv2.gif)
     - g. Las esferas tienen físicas, el cubo es de tipo IsTrigger y mecánico.
          - la esfera cae, pero el cubo traspasa el suelo al caer indefinidamente.
          ![gif ejercicio 8](/gifs/Ejercicio8gv1.gif)
     - h. Una esfera y el cubo son físicos y la esfera tiene 10 veces la masa del cubo, se impide la rotación del cubo sobre el plano XZ.
          - El cubo al caer pegado a la esfera no está con exactitud es la misma posición XZ que la esfera, está ligeramente desplazado, la esfera de encima se
          desplazará afectada por el cubo.
          ![gif ejercicio 8](/gifs/Ejercicio8h.gif)
  
9. Sobre la escena que has trabajado ubica un cubo que represente un personaje que vas a mover. Se debe implementar un script que haga de CharacterController. 
Cuando el jugador pulse las teclas de flecha (o aswd) el jugador se moverá en la dirección que estos ejes indican.
    - a. Crear un script para el personaje que lo desplace por la pantalla, sin aplicar simulación física.
    - b. Agregar un campo público que permita graduar la velocidad del movimiento desde el inspector de objetos.
    - c. Utilizar la tecla de espaciado para incrementar la velocidad del desplazamiento en el tiempo de juego.
    - d. Estar a la escucha de si el usuario ha utilizado los ejes virtuales. Elegir cuáles se va a permitir utilizar: flechas, awsd.
    - e. Elegir otros ejes virtuales para el giro y girar al jugador sobre el eje OY (up).
    
   ![gif ejercicio 9](/gifs/Ejercicio9.gif)
   
10. Sobre la escena que has trabajado programa los scripts necesarios para las siguientes acciones:
  - Se deben incluir varios cilindros sobre la escena. Cada vez que el objeto jugador colisione con alguno de ellos,  se debe mostrar en la consola 
  un mensaje indicando el nombre del cilindro con el que colisiona, cambiar a color rojo y el jugador aumentar la puntuación.
  
  ![gif ejercicio 10](/gifs/Ejercicio10.gif)
