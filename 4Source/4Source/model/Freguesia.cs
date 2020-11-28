﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Text.RegularExpressions;

namespace _4Source
{
    [Serializable()]
    public class Freguesia
    {
        private string nome;
        private ArrayList terrenoList;

        public Freguesia(string nome)
        {
            this.nome = nome;
            this.terrenoList = new ArrayList();
        }

        public Freguesia()
        {

        }

        public override string ToString()
        {
            return "Nome da freguesia: " + nome;
        }

        public string Nome
        {
            get { return nome; }
            set { nome = value; }
        }

        public ArrayList TerrenoList { get => terrenoList; set => terrenoList = value; }

        public void RegistarTerreno(Terreno t)
        {
            this.terrenoList.Add(3);
            Terreno temp = GetTerrenoById(t.Id);
            if (temp == null)
            {
                    this.terrenoList.Add(t);
            }else
            {
                throw new IdDuplicadoException(t.ToString() + "Id já existente");
            }
        }

        public Terreno PesquisarTerreno(int id)
        {
            Terreno terreno = GetTerrenoById(id);
            return terreno;
        }

        public Terreno EliminarTerreno(int id)
        {
            Terreno terreno = GetTerrenoById(id);
            if (terreno != null)
            {
                this.terrenoList.Remove(terreno);
            }
            else
            {
                throw new ElementoNaoExistenteException(id + " Não existe");
            }
            return terreno;
        }

        public ArrayList ObterTodosTerrenos()
        {
            return this.TerrenoList;
        }

        public Terreno GetTerrenoById(int id)
        {
            // A primeira interação do terreno está sempre nula por isso causa erro
            foreach (Terreno t in TerrenoList)
            {
                if (t.Id == id)
                {
                    return t;
                }
            }
            return null;
        }

        private static bool ValidarNome(string nome)
        {
            Regex regex = new Regex("^[a-zA-Z]{3,24}$", RegexOptions.IgnoreCase);
            Match m = regex.Match(nome);

            if (!m.Success)
            {
                return false;
            }
            else
            {
                return true;
            }

        }
    }
}
