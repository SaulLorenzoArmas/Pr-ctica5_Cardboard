//-----------------------------------------------------------------------
// <copyright file="ObjectController.cs" company="Google LLC">
// Copyright 2020 Google LLC
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//     http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// </copyright>
//-----------------------------------------------------------------------

using System.Collections;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;

/// <summary>
/// Controls target objects behaviour.
/// </summary>
public class ObjectController : MonoBehaviour
{

    public GameObject pokemon;
    public AudioSource musicaAmbiente;
    public AudioSource sonidoPokemon;
    public TextMeshProUGUI textoPokemon;
    public Datos_personaje jugador;
    public NotificadorCofre notificador;


    private Renderer[] rendererPokemon;
    private SphereCollider cuerpito;
    private bool meMuevo;
    private float velocidad = 1f;


    /// <summary>
    /// Start is called before the first frame update.
    /// </summary>
    public void Start()
    {
        rendererPokemon = pokemon.GetComponentsInChildren<Renderer>();
        cuerpito = GetComponent<SphereCollider>();
        pokemon.transform.LookAt(jugador.transform.position);
        notificador.OnEventoVista += acercamiento;
        meMuevo = false;

    }  
    public void Update() {
        if (meMuevo && Vector3.Distance(pokemon.transform.position, jugador.transform.position) > 3.5f) {
            Vector3 vectorDistancia = jugador.transform.position - transform.position;
            pokemon.transform.Translate(vectorDistancia.normalized * velocidad * Time.deltaTime, Space.World);
        } else if (meMuevo && Vector3.Distance(pokemon.transform.position, jugador.transform.position) <= 3.5f) {
            meMuevo = false;
        }
    } 

    /// <summary>
    /// This method is called by the Main Camera when it starts gazing at this GameObject.
    /// </summary>
    public void OnPointerEnter()
    {
        foreach (Renderer renderActual in rendererPokemon)
        {
            renderActual.enabled = false;
        }
        cuerpito.enabled = false;
        musicaAmbiente.volume = 0.15f;
        sonidoPokemon.Play();
        jugador.puntos += 1;
        textoPokemon.text = "Número de Pokemon atrapados: " + jugador.puntos;
        // Esperar a que el sonido se reproduzca 
        Invoke("subirMusica", sonidoPokemon.clip.length);
    }
    //Esta para que no salga un error (de cosas de la cardboard)
    public void OnPointerExit() {}
    private void subirMusica() {
        musicaAmbiente.volume = 1f;
    }
    private void acercamiento() {
        meMuevo = true;
    }
}
