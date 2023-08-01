﻿using ConsoleTesting.Models.Scenes;
using DB.Models.Characters;
using DB.Models.TextSwitcher;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameBuilder.Factories
{
    public class SceneFactory
    {
        private SceneFactory() { }

        private static SceneFactory instance;

        public static SceneFactory Instance 
        { 
            get
            {
                if(instance == null)
                    instance = new SceneFactory();
                return instance;
            } 
        }

        public StandardScene CreateStandardScene(string dialogueText, DialogueCharacter? dialogueCharacter = null, IEnumerable<SpriteCharacter>? characters = null)
        {
            Dialogue dialogue = new Dialogue
            {
                Text = dialogueText,
                Character = dialogueCharacter,
            };

            return new StandardScene
            {
                Dialogue = dialogue,
                Characters = characters
            };
        }
    }
}