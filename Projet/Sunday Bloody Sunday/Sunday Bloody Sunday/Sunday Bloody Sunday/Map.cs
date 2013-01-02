using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace Sunday_Bloody_Sunday
{
    class Map
    {
        // FIELDS
        Rectangle MapTexture;
        public Player joueur;
        public List<IA> liste_ia;
        IA ia;
        PhysicsEngine map_physique;


        // CONSTRUCTOR
        public Map(Player j1,PhysicsEngine map_physique)
        {
            MapTexture = new Rectangle(0, 0, 800, 480);
            this.joueur = j1;
            this.map_physique = map_physique;
            this.liste_ia = new List<IA>();
            IA ia1 = new IA(120, 48);
            IA ia2 = new IA(160, 48);
            IA ia3 = new IA(400, 480);
            this.liste_ia.Add(ia1);
            this.liste_ia.Add(ia2);
            this.liste_ia.Add(ia3);
        }


        // METHODS
        // Get the width of the map
        public int Width
        {
            get { return MapTexture.Width; }
        }

        // Get the height of the map
        public int Height
        {
            get { return MapTexture.Height; }
        }

        //Verifie la possibilite des actions du heros
        public void action_hero()
        {
            if (joueur.actionjoueur == "up" || joueur.actionjoueur == "down" || joueur.actionjoueur == "left" || joueur.actionjoueur == "right")
            {
                if (this.joueur.actionjoueur == "up")
                {
                    if (!(map_physique.mur(this.joueur.futur_position_X_gauche(), this.joueur.futur_position_Y_haut()))
                     && !(map_physique.mur(this.joueur.futur_position_X_droite(), this.joueur.futur_position_Y_haut())))
                        this.joueur.mise_a_jour(joueur.actionjoueur);
                    this.joueur.actionjoueur = "";
                }

                if (this.joueur.actionjoueur == "down")
                {
                    if (!(map_physique.mur(this.joueur.futur_position_X_gauche(), this.joueur.futur_position_Y_bas()))
                     && !(map_physique.mur(this.joueur.futur_position_X_droite(), this.joueur.futur_position_Y_bas())))
                        this.joueur.mise_a_jour(joueur.actionjoueur);
                    this.joueur.actionjoueur = "";
                }

                if (this.joueur.actionjoueur == "left")
                {
                    if (!(map_physique.mur(this.joueur.futur_position_X_gauche(), this.joueur.futur_position_Y_haut()))
                     && !(map_physique.mur(this.joueur.futur_position_X_gauche(), this.joueur.futur_position_Y_bas())))
                        this.joueur.mise_a_jour(joueur.actionjoueur);
                    this.joueur.actionjoueur = "";
                }

                if (this.joueur.actionjoueur == "right")
                {
                    if (!(map_physique.mur(this.joueur.futur_position_X_droite(), this.joueur.futur_position_Y_haut()))
                     && !(map_physique.mur(this.joueur.futur_position_X_droite(), this.joueur.futur_position_Y_bas())))
                        this.joueur.mise_a_jour(joueur.actionjoueur);
                    this.joueur.actionjoueur = "";
                }


            }
            this.joueur.actionjoueur = ""; // "Remet à zéros" les actions du joueurs
        }

        //Verifie la possibilite des actions de l'IA
        public void action_ia()
        {
            if (ia.actionIA == "up" || ia.actionIA == "down" || ia.actionIA == "left" || ia.actionIA == "right")
            {
                if (this.ia.actionIA == "up")
                {
                    if (!(map_physique.mur(this.ia.futur_position_X_gauche(), this.ia.futur_position_Y_haut()))
                     && !(map_physique.mur(this.ia.futur_position_X_droite(), this.ia.futur_position_Y_haut())))
                        this.ia.mise_a_jour(ia.actionIA);
                    this.ia.actionIA = "";
                }

                if (this.ia.actionIA == "down")
                {
                    if (!(map_physique.mur(this.ia.futur_position_X_gauche(), this.ia.futur_position_Y_bas()))
                     && !(map_physique.mur(this.ia.futur_position_X_droite(), this.ia.futur_position_Y_bas())))
                        this.ia.mise_a_jour(ia.actionIA);
                    this.ia.actionIA = "";
                }
                //
                if (this.ia.actionIA == "left")
                {
                    if (!(map_physique.mur(this.ia.futur_position_X_gauche(), this.ia.futur_position_Y_haut()))
                     && !(map_physique.mur(this.ia.futur_position_X_gauche(), this.ia.futur_position_Y_bas())))
                        this.ia.mise_a_jour(ia.actionIA);
                    this.ia.actionIA = "";
                }
                //
                if (this.ia.actionIA == "right")
                {
                    if (!(map_physique.mur(this.ia.futur_position_X_droite(), this.ia.futur_position_Y_haut()))
                     && !(map_physique.mur(this.ia.futur_position_X_droite(), this.ia.futur_position_Y_bas())))
                        this.ia.mise_a_jour(ia.actionIA);
                    this.ia.actionIA = "";
                }


            }
            this.joueur.actionjoueur = ""; // "Remet à zéros" les actions du joueurs
        }

        //Gere le deplacement de l'ia
        public void pathfing(ref string action)
        {
            if (this.joueur.PlayerTexture.X < this.ia.IATexture.X)
            {
                action = "left";
                if (!(map_physique.mur(this.ia.futur_position_X_gauche(), this.ia.futur_position_Y_haut()))
                     && !(map_physique.mur(this.ia.futur_position_X_gauche(), this.ia.futur_position_Y_bas())))
                {
                }
                else
                {
                    if (this.joueur.PlayerTexture.Y < this.ia.IATexture.Y)
                    {
                        action = "up";
                        if (!(map_physique.mur(this.ia.futur_position_X_gauche(), this.ia.futur_position_Y_haut()))
                         && !(map_physique.mur(this.ia.futur_position_X_droite(), this.ia.futur_position_Y_haut())))
                        {
                        }
                        else
                        {
                            action = "";
                        }
                    }
                    else if (this.joueur.PlayerTexture.Y > this.ia.IATexture.Y)
                    {
                        action = "down";
                        if (!(map_physique.mur(this.ia.futur_position_X_gauche(), this.ia.futur_position_Y_bas()))
                         && !(map_physique.mur(this.ia.futur_position_X_droite(), this.ia.futur_position_Y_bas())))
                        {
                            
                        }
                        else
                        {
                            action = "";
                        }
                    }
                }
            }
            else if (this.joueur.PlayerTexture.X > this.ia.IATexture.X)
            {
                action = "right";
                if (!(map_physique.mur(this.ia.futur_position_X_droite(), this.ia.futur_position_Y_haut()))
                     && !(map_physique.mur(this.ia.futur_position_X_droite(), this.ia.futur_position_Y_bas())))
                {
                    
                }
                else
                {
                    action = "up";
                    if (this.joueur.PlayerTexture.Y < this.ia.IATexture.Y)
                    {

                        if (!(map_physique.mur(this.ia.futur_position_X_gauche(), this.ia.futur_position_Y_haut()))
                         && !(map_physique.mur(this.ia.futur_position_X_droite(), this.ia.futur_position_Y_haut())))
                        {
                            
                        }
                        else
                        {
                            action = "";
                        }
                    }
                    else if (this.joueur.PlayerTexture.Y > this.ia.IATexture.Y)
                    {
                        action = "down";
                        if (!(map_physique.mur(this.ia.futur_position_X_gauche(), this.ia.futur_position_Y_bas()))
                         && !(map_physique.mur(this.ia.futur_position_X_droite(), this.ia.futur_position_Y_bas())))
                        {
                            
                        }
                        else
                        {
                            action = "";
                        }
                    }
                }
            }
            else if (this.joueur.PlayerTexture.Y < this.ia.IATexture.Y)
            {
                action = "up";

                if (!(map_physique.mur(this.ia.futur_position_X_gauche(), this.ia.futur_position_Y_haut()))
                 && !(map_physique.mur(this.ia.futur_position_X_droite(), this.ia.futur_position_Y_haut())))
                {
                   
                }
                else
                {
                    if (this.joueur.PlayerTexture.X < this.ia.IATexture.X)
                    {
                        action = "left";
                        if (!(map_physique.mur(this.ia.futur_position_X_gauche(), this.ia.futur_position_Y_haut()))
                             && !(map_physique.mur(this.ia.futur_position_X_gauche(), this.ia.futur_position_Y_bas())))
                        {
                            
                        }
                        else
                        {
                            action = "";
                        }
                    }
                    else if (this.joueur.PlayerTexture.X > this.ia.IATexture.X)
                    {
                        action = "right";
                        if (!(map_physique.mur(this.ia.futur_position_X_droite(), this.ia.futur_position_Y_haut()))
                             && !(map_physique.mur(this.ia.futur_position_X_droite(), this.ia.futur_position_Y_bas())))
                        {
                            
                        }
                        else
                        {
                            action = "";
                        }
                    }
                }
            }
            else if (this.joueur.PlayerTexture.Y > this.ia.IATexture.Y)
            {
                action = "down";
                if (!(map_physique.mur(this.ia.futur_position_X_gauche(), this.ia.futur_position_Y_bas()))
                 && !(map_physique.mur(this.ia.futur_position_X_droite(), this.ia.futur_position_Y_bas())))
                {
                    
                }
                else
                {
                    action = "up";
                    if (this.joueur.PlayerTexture.Y < this.ia.IATexture.Y)
                    {

                        if (!(map_physique.mur(this.ia.futur_position_X_gauche(), this.ia.futur_position_Y_haut()))
                         && !(map_physique.mur(this.ia.futur_position_X_droite(), this.ia.futur_position_Y_haut())))
                        {
                            
                        }
                        else
                        {
                            action = "";
                        }
                    }
                    else if (this.joueur.PlayerTexture.Y > this.ia.IATexture.Y)
                    {
                        action = "down";
                        if (!(map_physique.mur(this.ia.futur_position_X_gauche(), this.ia.futur_position_Y_bas()))
                         && !(map_physique.mur(this.ia.futur_position_X_droite(), this.ia.futur_position_Y_bas())))
                        {
                            
                        }
                        else
                        {
                            action = "";
                        }
                    }
                }
            }
            else if (this.joueur.PlayerTexture.Y < this.ia.IATexture.Y)
            {
                action = "up";

                if (!(map_physique.mur(this.ia.futur_position_X_gauche(), this.ia.futur_position_Y_haut()))
                 && !(map_physique.mur(this.ia.futur_position_X_droite(), this.ia.futur_position_Y_haut())))
                {
                   
                }
                else
                {
                    if (this.joueur.PlayerTexture.X < this.ia.IATexture.X)
                    {
                        action = "left";
                        if (!(map_physique.mur(this.ia.futur_position_X_gauche(), this.ia.futur_position_Y_haut()))
                             && !(map_physique.mur(this.ia.futur_position_X_gauche(), this.ia.futur_position_Y_bas())))
                        {
                            
                        }
                        else
                        {
                            action = "";
                        }
                    }
                    else if (this.joueur.PlayerTexture.X > this.ia.IATexture.X)
                    {
                        action = "right";
                        if (!(map_physique.mur(this.ia.futur_position_X_droite(), this.ia.futur_position_Y_haut()))
                             && !(map_physique.mur(this.ia.futur_position_X_droite(), this.ia.futur_position_Y_bas())))
                        {
                            
                        }
                        else
                        {
                            action = "";
                        }
                    }
                
                }
            }

        }

        //Gere le raffraichissement de la liste d'ia
        public void update_ia()
        {
            foreach (IA ia in liste_ia)
            {
                this.ia = ia;
                pathfing(ref this.ia.action);
                action_ia();
                this.ia.Update();
            }
        }

        //Gere l'affichage de la liste d'ia
        public void draw_ia(SpriteBatch spriteBatch)
        {
            foreach (IA ia in liste_ia)
            {
                this.ia = ia;
                this.ia.Draw(spriteBatch);
            }
        }
        // UPDATE & DRAW
        public void Update(MouseState mouse, KeyboardState keyboard)
        {
            // Update l'objet joueur contenu par la map
            this.joueur.Update(mouse, keyboard);
            action_hero();
            update_ia();
            
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Ressources.Map, this.MapTexture, Color.CadetBlue);
            this.joueur.Draw(spriteBatch);
            draw_ia(spriteBatch);
            
        }
    }
}
