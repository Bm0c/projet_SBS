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
        public List<Projectile> liste_projectile = new List<Projectile>();
        Projectile balle;
        IA ia;
        PhysicsEngine map_physique;
        int compteur = 0;
        private Rectangle futur_rectangle;
        int compteur_2 = 0;
        Random rand = new Random();
        Sound moteur_son = new Sound();
        public bool menu = true;


        // CONSTRUCTOR
        public Map(Player j1, PhysicsEngine map_physique)
        {
            MapTexture = new Rectangle(0, 0, 800, 480);
            this.joueur = j1;
            this.map_physique = map_physique;
            this.liste_ia = new List<IA>();
            IA ia1 = new IA(120, 48);
            IA ia2 = new IA(160, 48);
            IA ia3 = new IA(400, 460);
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
            this.joueur.maj_direction(joueur.actionjoueur);
            if (joueur.actionjoueur == "up" || joueur.actionjoueur == "down" || joueur.actionjoueur == "left" || joueur.actionjoueur == "right")
            {
                if (this.joueur.actionjoueur == "up")
                {
                    if (!(map_physique.mur(this.joueur.futur_position_X_gauche(), this.joueur.futur_position_Y_haut()))
                     && !(map_physique.mur(this.joueur.futur_position_X_droite(), this.joueur.futur_position_Y_haut())) && collision_entite_hero())
                        this.joueur.mise_a_jour(joueur.actionjoueur);
                    this.joueur.actionjoueur = "";
                }

                if (this.joueur.actionjoueur == "down")
                {
                    if (!(map_physique.mur(this.joueur.futur_position_X_gauche(), this.joueur.futur_position_Y_bas()))
                     && !(map_physique.mur(this.joueur.futur_position_X_droite(), this.joueur.futur_position_Y_bas())) && collision_entite_hero())
                        this.joueur.mise_a_jour(joueur.actionjoueur);
                    this.joueur.actionjoueur = "";
                }

                if (this.joueur.actionjoueur == "left")
                {
                    if (!(map_physique.mur(this.joueur.futur_position_X_gauche(), this.joueur.futur_position_Y_haut()))
                     && !(map_physique.mur(this.joueur.futur_position_X_gauche(), this.joueur.futur_position_Y_bas())) && collision_entite_hero())
                        this.joueur.mise_a_jour(joueur.actionjoueur);
                    this.joueur.actionjoueur = "";
                }

                if (this.joueur.actionjoueur == "right")
                {
                    if (!(map_physique.mur(this.joueur.futur_position_X_droite(), this.joueur.futur_position_Y_haut()))
                     && !(map_physique.mur(this.joueur.futur_position_X_droite(), this.joueur.futur_position_Y_bas())) && collision_entite_hero())
                        this.joueur.mise_a_jour(joueur.actionjoueur);
                    this.joueur.actionjoueur = "";
                }


            }
            this.joueur.actionjoueur = ""; // "Remet à zéros" les actions du joueurs
        }

        public bool collision_entite_hero()
        {
            futur_rectangle = this.joueur.rectangle();
            bool test = true;
            foreach (IA ia in liste_ia)
            {
                if (test)
                {
                    test = !futur_rectangle.Intersects(ia.rectangle());
                }
            }
            return test;
        }

        //Verifie la possibilite des actions de l'IA
        public void action_ia(IA ia)
        {
            if (ia.actionIA == "up" || ia.actionIA == "down" || ia.actionIA == "left" || ia.actionIA == "right")
            {
                if (this.ia.actionIA == "up")
                {
                    if (!(map_physique.mur(this.ia.futur_position_X_gauche(), this.ia.futur_position_Y_haut()))
                     && !(map_physique.mur(this.ia.futur_position_X_droite(), this.ia.futur_position_Y_haut())) && collision_entite_ia(ia))
                        this.ia.mise_a_jour(ia.actionIA);
                    this.ia.actionIA = "";
                }

                if (this.ia.actionIA == "down")
                {
                    if (!(map_physique.mur(this.ia.futur_position_X_gauche(), this.ia.futur_position_Y_bas()))
                     && !(map_physique.mur(this.ia.futur_position_X_droite(), this.ia.futur_position_Y_bas())) && collision_entite_ia(ia))
                        this.ia.mise_a_jour(ia.actionIA);
                    this.ia.actionIA = "";
                }
                //
                if (this.ia.actionIA == "left")
                {
                    if (!(map_physique.mur(this.ia.futur_position_X_gauche(), this.ia.futur_position_Y_haut()))
                     && !(map_physique.mur(this.ia.futur_position_X_gauche(), this.ia.futur_position_Y_bas())) && collision_entite_ia(ia))
                        this.ia.mise_a_jour(ia.actionIA);
                    this.ia.actionIA = "";
                }
                //
                if (this.ia.actionIA == "right")
                {
                    if (!(map_physique.mur(this.ia.futur_position_X_droite(), this.ia.futur_position_Y_haut()))
                     && !(map_physique.mur(this.ia.futur_position_X_droite(), this.ia.futur_position_Y_bas())) && collision_entite_ia(ia))
                        this.ia.mise_a_jour(ia.actionIA);
                    this.ia.actionIA = "";
                }


            }
            this.joueur.actionjoueur = ""; // "Remet à zéros" les actions du joueurs
        }

        public bool collision_entite_ia(IA ia)
        {
            futur_rectangle = this.ia.rectangle();
            bool test = true;
            foreach (IA ia1 in liste_ia)
            {
                if ((test) && !(ia1.est_update))
                {
                    test = !futur_rectangle.Intersects(ia1.rectangle/*_ia*/());
                }
            }
            if (test)
            {
                test = !futur_rectangle.Intersects(joueur.rectangle());
            }

            return test;
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
                if (ia.Health > 0)
                {
                    ia.est_update = true;
                    this.ia = ia;
                    pathfing(ref this.ia.action);
                    action_ia(ia);
                    this.ia.Update();
                    ia.est_update = false;
                }
                else
                {
                    ia.IATexture.X = -42;
                    ia.IATexture.Y = -42;
                }
            }
            if (compteur_2 > 30)
            {
                int spawn = rand.Next(4);
                if (spawn == 00)
                {
                    liste_ia.Add(new IA(144, 48));
                    moteur_son.PlayPika2();
                }
                else if (spawn == 1)
                {
                    liste_ia.Add(new IA(0, 272));
                    moteur_son.PlayPika();
                }
                else
                {
                    liste_ia.Add(new IA(400, 470));
                    moteur_son.PlayPika();
                }
                
                compteur_2 = 0;
            }
            compteur_2++;
        }

        public void collision_balle(Projectile balle)
        {
            if (!(map_physique.mur(balle.futur_x(), balle.futur_y())))
            {
                balle.update_coordonne();
            }
            else
            {
                balle.isVisible = false;
            }
        }

        public void collision_entite_balle(Projectile balle)
        {
            futur_rectangle = balle.rectangle();
            bool test = true;
            foreach (IA ia1 in liste_ia)
            {
                if ((test))
                {
                    if (futur_rectangle.Intersects(ia1.rectangle()))
                    {
                        balle.isVisible = false;
                        test = false;
                        ia1.Health = ia1.Health - balle.Damage;

                    }
                }
            }
            /*
            return test;*/
        }

        public void update_projectiles(KeyboardState keyboard)
        {
            foreach (Projectile balle in liste_projectile)
            {
                balle.init = 0;
            }

            foreach (Projectile balle in liste_projectile)
            {
                while ((balle.init < balle.projectileMoveSpeed) && balle.isVisible)
                {

                    collision_entite_balle(balle);
                    collision_balle(balle);
                    balle.init++;
                }
            }

            if ((keyboard.IsKeyDown(Keys.S)) && compteur >= 6)
            {
                balle = new Projectile(Ressources.Projectile, (int)this.joueur.centre().X, (int)this.joueur.centre().Y, 10, this.joueur.Direction, 50);
                liste_projectile.Add(balle);
                compteur = 0;
                Player.Ammo--;
                moteur_son.PlayTire();
                
            }
            compteur++;
        }

        //Gere l'affichage de la liste d'ia

        public void swap(ref IA a, ref IA b)
        {
            IA c = a;
            a = b;
            b = c;
        }

        public int minimum(IA[] tableau, int d, int f)
        {
            int pos = d;
            int i = d + 1;
            while (i < tableau.Length)
            {
                if (tableau[i].IATexture.Y < tableau[pos].IATexture.Y)
                {
                    pos = i;
                }
                i++;
            }

            return pos;
        }

        public void tri(ref IA[] tableau)
        {
            int i = 0;
            while (i < tableau.Length)
            {
                swap(ref tableau[i], ref tableau[minimum(tableau, i, tableau.Length)]);
                i++;
            }
        }

        public void draw_ordre(SpriteBatch spriteBatch)
        {
            IA[] tableau_ia = new IA[liste_ia.Count];
            liste_ia.CopyTo(tableau_ia);
            tri(ref tableau_ia);
            bool test = true;
            foreach (IA ia in tableau_ia)
            {


                ia.Draw(spriteBatch);
                if ((ia.IATexture.Y < joueur.PlayerTexture.Y) && test)
                {
                    this.joueur.Draw(spriteBatch);
                }
            }
        }
        // UPDATE & DRAW
        public void Update(MouseState mouse, KeyboardState keyboard)
        {
            // Update l'objet joueur contenu par la map
            this.joueur.Update(mouse, keyboard);
            action_hero();
            update_ia();
            update_projectiles(keyboard);




        }

        public void Draw(SpriteBatch spriteBatch)
        {

            spriteBatch.Draw(Ressources.Map, this.MapTexture, Color.CadetBlue);
            draw_ordre(spriteBatch);
            foreach (Projectile projectile in liste_projectile)
            {
                projectile.Draw(spriteBatch);
            }

        }
    }
}
