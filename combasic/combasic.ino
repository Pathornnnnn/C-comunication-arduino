String data;
char d1;
String x;
void setup() {
  // put your setup code here, to run once:
  Serial.begin(9600);
}

void loop() {
  // put your main code here, to run repeatedly:
  /*protocal or pattern in use to comunication data c# to arduino
   *      Explan
   *      
   *      Data in send serial port consists of mode,data such A255,B122,C522
   *      
   *      part 1 mode
   *      fist index of character. we will get to define mode or select mode
   *      
   *      part 2 data
   *      second index - ... last index we will get data to process from GUI
   *      
   *      Example
   *      ----------------
   *      data = A255
   *      
   *      data[0] = A   first character   
   *                    (index = 0)
   *      -------MODE-----------             
   *      
   *      
   *      data.substring(1,-1) = 255   second    -  last character 
   *                                  (index = 1 -  index = -1)
   *      -------DATA USE IN PROCESS---------
   */
  if(Serial.available()){
    data = Serial.readString(); //read data form serial port
    d1 = data.charAt(0); //read data first character store in d1
    x = data.substring(1,-1); //split character second of data variable  ... last character store in x
    switch(d1){
      case 'A': //send serial data = mode A. will execute in case a ...
        Serial.println("Mode A : "+x);
        /* do anything what you want*/
        break;
      case 'B': //send serial data = mode B. will execute in case B ...
        Serial.println("Mode B : "+x); 
        /* do anything what you want*/
        break;
      case 'C': //send serial data = mode C. will execute in case C ...
        Serial.println("Mode C : "+x); 
        /* do anything what you want*/
        break;
    }
  }
}
