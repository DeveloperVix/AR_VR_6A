using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Juego : MonoBehaviour
{
    public float scala1 = 10.0f;
    public float scala2 = 20.0f;
    public float scala1M = 20.0f;
    public float scala2M = 30.0f;
    public float rota = 30.0f;
    public float traslada = 5.0f;
    public int cuenta = 0;
    public int cuenta2 = 0;
    public int cuenta3 = 0;
    private MeshRenderer meshRenderer;
    public Material defaultMaterial, selected;
    public bool[] estado=new bool[6];
    public bool[] menu = new bool[6];
    public bool[] con = new bool[5];
    public int[] sema= new int[4];
    public int[] color = new int[4];
    public int[] piano = new int[9];
    // Start is called before the first frame update
    void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        for (int i = 0; i < 6; i++) {
            estado[i] = false;
            menu[i] = false;
        }
        for (int i = 0; i < 4; i++)
        {
            sema[i] = 0;
        }
        for (int i = 0; i < 4; i++)
        {
            color[i] = 0;
        }
        for (int i = 0; i < 9; i++)
        {
            piano[i] = 0;
        }
        for (int i = 0; i < 5; i++)
        {
            con[i] =false;
        }
    }
    void Update(){
        //solo asi se me ocurrio el comprobarlo sin error 
        if (estado[0]==true && estado[1] == true && estado[2] == true && estado[3] == true && estado[4] == true && estado[5] == true) {
            Debug.Log("GANASTE");
        }
    }
    // semaforro si se prende uno que esta apagado se apaga si prende y si esta prendido se apaga y sera de 1 2 o 3 movimientos ganar prender todos              1
    //como cabio el material :´V
    public void semaforo1(){
        menu[0] = true;
        if (estado[0] == false) {
            if (sema[1] == 1) {
                sema[1] = 0;
                //GameObject.FindWithTag("Cube2").material = defaultMaterial; 
            }
            else {
                sema[1] = 1;
                //GameObject.FindWithTag("Cube2").meshRenderer.material = selected;
            }
            if (sema[0] == 1 && sema[1] == 1 && sema[2] == 1 && sema[3] == 1){
                estado[0] = true;
            }
        }
    }
    public void semaforo2(){
        menu[0] = true;
        if (estado[0] == false){
            if (sema[1] == 1){
                sema[1] = 0;
                //GameObject.FindWithTag("Cube2").material = defaultMaterial; 
            }
            else
            {
                sema[1] = 1;
                //GameObject.FindWithTag("Cube2").meshRenderer.material = selected;
            }
            if (sema[2] == 1){
                sema[2] = 0;
                //GameObject.FindWithTag("Cube2").material = defaultMaterial; 
            }
            else
            {
                sema[2] = 1;
                //GameObject.FindWithTag("Cube2").meshRenderer.material = selected;
            }
            if (sema[3] == 1){
                sema[3] = 0;
                //GameObject.FindWithTag("Cube2").material = defaultMaterial; 
            }
            else
            {
                sema[3] = 1;
                //GameObject.FindWithTag("Cube2").meshRenderer.material = selected;
            }
            if (sema[0] == 1 && sema[1] == 1 && sema[2] == 1 && sema[3] == 1){
                estado[0] = true;
            }
        }
    }
    public void semaforo3(){
        menu[0] = true;
        if (estado[0] == false){
            if (sema[1] == 1){
                sema[1] = 0;
                //GameObject.FindWithTag("Cube2").material = defaultMaterial; 
            }
        }
            else {
                sema[1] = 1;
                 //GameObject.FindWithTag("Cube2").meshRenderer.material = selected;
        }
            if (sema[0] == 1){
                sema[0] = 0;
                //GameObject.FindWithTag("Cube2").material = defaultMaterial; 
        }
        else
        {
                sema[0] = 1;
            //GameObject.FindWithTag("Cube2").meshRenderer.material = selected;
        }
        if (sema[0] == 1 && sema[1] == 1 && sema[2] == 1 && sema[3] == 1)
            {
                estado[0] = true;
            }
        }    
    //********************************************************************************************************************************************               
    //Juego de la cerradura se tiene que seguri la secuencia corecta para ganar  derecha , derecha, izquierda, derecha , izquierda                               2
    public void rotaIzqBot1(){
        menu[1] = true;
        if (estado[1] == false){
            if (cuenta < 6) {
                GameObject.FindWithTag("Cerrojo").transform.Rotate(0, 0, rota * Time.deltaTime);
                con[cuenta] = true;
                cuenta+=1;
            }
            if(cuenta>=6){
                if (con[0] == false && con[1] == false && con[2] == true && con[3] == false && con[5] == true)
                {
                    estado[1] = true;
                }
                else {
                    cuenta = 0;
                    for (int i = 0; i < 5; i++)
                    {
                        con[i] = false;
                    }
                }
            }
        }
    }
    public void rotaDeBot2() {
        menu[1] = true;
        if (estado[1] == false){
            if (cuenta < 6)
            {
                GameObject.FindWithTag("Cerrojo").transform.Rotate(0, 0, -rota * Time.deltaTime);
                con[cuenta] = false;
                cuenta += 1;
            }
            if (cuenta >= 6)
            {
                if (con[0] == false && con[1] == false && con[2] == true && con[3] == false && con[5] == true)
                {
                    estado[1] = true;
                }
                else
                {
                    cuenta = 0;
                    for (int i = 0; i < 5; i++)
                    {
                        con[i] = false;
                    }
                }
            }
        }
    }
    //*********************************************************************************************************************************************
    //Juego del cubito se tien que logara que el cubo mida 115 en X y Y para ganar                                                                              3
    public void escala1(){
        menu[2] = true;
        if (estado[2] == false){            
                GameObject.FindWithTag("Cubito").transform.localScale += new Vector3(scala1, scala1, 0);
                if (GameObject.FindWithTag("Cubito").transform.localScale == new Vector3(115, 115, 4)){
                    estado[2] = true;
                }                        
        }
    }
    public void escala2(){
        menu[2] = true;
        if (estado[2] == false)
        {
            GameObject.FindWithTag("Cubito").transform.localScale += new Vector3(scala2, scala2, 0);
            if (GameObject.FindWithTag("Cubito").transform.localScale == new Vector3(115, 115, 4))
            {
                estado[2] = true;
            }
        }
    }
    public void escala1M(){
        menu[2] = true;
        if (estado[2] == false)
        {
            GameObject.FindWithTag("Cubito").transform.localScale -= new Vector3(scala1M, scala1M, 0);
            if (GameObject.FindWithTag("Cubito").transform.localScale == new Vector3(115, 115, 4))
            {
                estado[2] = true;
            }
        }
    }
    public void escala2M(){
        menu[2] = true;
        if (estado[2] == false)
        {
            GameObject.FindWithTag("Cubito").transform.localScale -= new Vector3(scala2M, scala2M, 0);
            if (GameObject.FindWithTag("Cubito").transform.localScale == new Vector3(115, 115, 4))
            {
                estado[2] = true;
            }
        }
    }
    //*********************************************************************************************************************************************
    //toca el piano para ganra 1,2,1,2,1,3,4,5,6                                                                                                                 4
    public void Piano1(){
        menu[3] = true;
        if (estado[3] == false)
        {
            piano[cuenta2] = 1;
            cuenta2 += 1;
            if (cuenta >= 9){
                if (piano[0] == 1 && piano[1] == 2 && piano[2] == 1 && piano[3] == 2 && piano[4] == 1 && piano[5] == 3 && piano[6] == 4 && piano[7] == 5 && piano[8] == 6)
                {
                    estado[3] = true;
                }
                else {
                    cuenta2 = 0;
                }
            }
        }
    }
    public void Piano2()
    {
        menu[3] = true;
        if (estado[3] == false)
        {
            piano[cuenta2] = 2;
            cuenta2 += 1;
            if (cuenta >= 9)
            {
                if (piano[0] == 1 && piano[1] == 2 && piano[2] == 1 && piano[3] == 2 && piano[4] == 1 && piano[5] == 3 && piano[6] == 4 && piano[7] == 5 && piano[8] == 6)
                {
                    estado[3] = true;
                }
                else
                {
                    cuenta2 = 0;
                }
            }
        }
    }
    public void piano3()
    {
        menu[3] = true;
        if (estado[3] == false)
        {
            piano[cuenta2] = 3;
            cuenta2 += 1;
            if (cuenta >= 9)
            {
                if (piano[0] == 1 && piano[1] == 2 && piano[2] == 1 && piano[3] == 2 && piano[4] == 1 && piano[5] == 3 && piano[6] == 4 && piano[7] == 5 && piano[8] == 6)
                {
                    estado[3] = true;
                }
                else
                {
                    cuenta2 = 0;
                }
            }
        }
    }
    public void Piano4()
    {
        menu[3] = true;
        if (estado[3] == false)
        {
            piano[cuenta2] = 4;
            cuenta2 += 1;
            if (cuenta >= 9)
            {
                if (piano[0] == 1 && piano[1] == 2 && piano[2] == 1 && piano[3] == 2 && piano[4] == 1 && piano[5] == 3 && piano[6] == 4 && piano[7] == 5 && piano[8] == 6)
                {
                    estado[3] = true;
                }
                else
                {
                    cuenta2 = 0;
                }
            }
        }
    }
    public void Piano5()
    {
        menu[3] = true;
        if (estado[3] == false)
        {
            piano[cuenta2] = 5;
            cuenta2 += 1;
            if (cuenta >= 9)
            {
                if (piano[0] == 1 && piano[1] == 2 && piano[2] == 1 && piano[3] == 2 && piano[4] == 1 && piano[5] == 3 && piano[6] == 4 && piano[7] == 5 && piano[8] == 6)
                {
                    estado[3] = true;
                }
                else
                {
                    cuenta2 = 0;
                }
            }
        }
    }
    public void piano6()
    {
        menu[3] = true;
        if (estado[3] == false)
        {
            piano[cuenta2] = 6;
            cuenta2 += 1;
            if (cuenta >= 9)
            {
                if (piano[0] == 1 && piano[1] == 2 && piano[2] == 1 && piano[3] == 2 && piano[4] == 1 && piano[5] == 3 && piano[6] == 4 && piano[7] == 5 && piano[8] == 6)
                {
                    estado[3] = true;
                }
                else
                {
                    cuenta2 = 0;
                }
            }
        }
    }
    //********************************************************************************************************************************************
    //secuencia de colores setien que seguir el orde de los color para qe funcione si no se sigue se reinicia automatico                                         5
    //porgramado para seguir solo una secuensia se puede porgramar mas secuencias para aumentar el nivel 
    public void rojo(){
        menu[4] = true;
        if (estado[4] == false){
            if (cuenta3 < 4){
                GameObject.FindWithTag("Cerrojo").transform.Rotate(0, 0, rota * Time.deltaTime);
                color[cuenta3] = 1;
                cuenta3 += 1;
            }
            if (cuenta >= 6){
                if (color[0] == 1 && color[1] == 4 && color[2] == 2 && color[3] == 3){
                    estado[4] = true;
                }
                else{
                    cuenta = 0;
                    for (int i = 0; i < 4; i++)
                    {
                        color[i] = 0;
                    }
                }
            }
        }
    }
    public void verde()
    {
        menu[4] = true;
        if (estado[4] == false)
        {
            if (cuenta3 < 4)
            {
                GameObject.FindWithTag("Cerrojo").transform.Rotate(0, 0, rota * Time.deltaTime);
                color[cuenta3] = 2;
                cuenta3 += 1;
            }
            if (cuenta >= 6)
            {
                if (color[0] == 1 && color[1] == 4 && color[2] == 2 && color[3] == 3)
                {
                    estado[4] = true;
                }
                else
                {
                    cuenta = 0;
                    for (int i = 0; i < 4; i++)
                    {
                        color[i] = 0;
                    }
                }
            }
        }
    }
    public void amari()
    {
        menu[4] = true;
        if (estado[4] == false)
        {
            if (cuenta3 < 4)
            {
                GameObject.FindWithTag("Cerrojo").transform.Rotate(0, 0, rota * Time.deltaTime);
                color[cuenta3] = 3;
                cuenta3 += 1;
            }
            if (cuenta >= 6)
            {
                if (color[0] == 1 && color[1] == 4 && color[2] == 2 && color[3] == 3)
                {
                    estado[4] = true;
                }
                else
                {
                    cuenta = 0;
                    for (int i = 0; i < 4; i++)
                    {
                        color[i] = 0;
                    }
                }
            }
        }
    }
    public void azul()
    {
        menu[4] = true;
        if (estado[4] == false)
        {
            if (cuenta3 < 4)
            {
                GameObject.FindWithTag("Cerrojo").transform.Rotate(0, 0, rota * Time.deltaTime);
                color[cuenta3] = 4;
                cuenta3 += 1;
            }
            if (cuenta >= 6)
            {
                if (color[0] == 1 && color[1] == 4 && color[2] == 2 && color[3] == 3)
                {
                    estado[4] = true;
                }
                else
                {
                    cuenta = 0;
                    for (int i = 0; i < 4; i++)
                    {
                        color[i] = 0;
                    }
                }
            }
        }
    }
    //*********************************************************************************************************************************************

        //me entro par el jugo de la pelotita no se si poner el detector de colicion en update o crearle su propio metodo 
        //es cuastion simpmetente que se compare las etiquedas para saber si colicion con la meta 
        //en teoria el jugo estari ya asi simplente con el RigidBody ya que estarai libre en el espacio y no cupa controles 
        //se creari el reseteo de este mismo haciento que tome sus valores iniciales 

    //Resetea el juego si esta activo y no se a ganado
    public void ReseteJu() {
        for (int i = 0; i < 6; i++) {
            if (estado[i] == false && menu[i] == true) {
                switch (i){
                    case 0:
                        for (int j = 0; j < 4; j++)
                        {
                            sema[j] = 0;
                        }
                        //y regresar colos a rojo :´v
                        break;
                    case 1:
                        //regresara  rotacion inicial 
                        GameObject.FindWithTag("Cerrojo").transform.Rotate(0, 0, 0 * Time.deltaTime);
                        cuenta = 0;
                        for (int f = 0; f < 5; f++)
                        {
                            con[f] = false;
                        }
                        break;
                    case 2:
                        GameObject.FindWithTag("Cubito").transform.localScale = new Vector3(45, 45, 4);
                        break;
                    case 3:
                        cuenta2 = 0;
                        for (int y = 0; y < 9; y++)
                        {
                            piano[y] = 0;
                        }
                        break;
                    case 4:
                        cuenta = 0;
                        for (int j = 0; j < 4; j++)
                        {
                            color[j] = 0;
                        }
                        break;
                    case 5:
                        GameObject.FindWithTag("pelotira").transform.position = new Vector3(-81.6f, 78.1f, -1.33f);
                        break;
                }
            }
        }
    }
    //*********************************************************************************************************************************************
    //borratodo el mundo 
    public void Reset()
    {
        for (int i = 0; i < 6; i++)
        {
            estado[i] = false;
            menu[i] = false;
        }
        for (int i = 0; i < 4; i++)
        {
            sema[i] = 0;
        }
        for (int i = 0; i < 5; i++)
        {
            con[i] = false;
        }
        for (int i = 0; i < 9; i++)
        {
            piano[i] = 0;
        }
        cuenta2 = 0;
        cuenta = 0;
        GameObject.FindWithTag("Cubito").transform.localScale = new Vector3(45, 45, 4);
    }
}
