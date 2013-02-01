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
        public List<Items> liste_box; //Liste Items
        public List<Items> liste_box2; //Liste Items secondaire, utilisée pour nettoyer la mémoire
        public List<DesctrutibleItems> liste_barrel; //Liste barrel
        public List<DesctrutibleItems> liste_barrel2; //Liste barrel secondaire, utilisée pour nettoyer la mémoire
        public List<ExplosionParticule> explosions; //Liste particules d'explosion
        public List<ExplosionParticule> explosions2; //Liste particules d'explosion secondaire, utilisée pour nettoyer la mémoire
        public List<Player> joueurs = new List<Player>();
        public List<Player> joueurs_2 = new List<Player>();
        public List<IA> liste_ia; //Liste des IA
        public List<IA> liste_ia2; //Liste IA secondaire, utilisée pour nettoyer la mémoire
        public List<Projectile> liste_projectile = new List<Projectile>(); //Liste des Projectiles
        public List<Projectile> liste_projectile2 = new List<Projectile>(); //Liste Projectiles secondaire, utilisée pour nettoyer la mémoire
        Projectile balle;
        IA ia;
        DesctrutibleItems explosiveBox;
        PhysicsEngine map_physique;
        private Rectangle futur_rectangle; //Rectangle utilisé por stocker des données
        int compteur = 0;
        Random rand = new Random();
        Sound moteur_son = new Sound();
        bool etape1 = false;
        bool etape2 = false;
        public bool game_over = false;
        GameTime gameTime = new GameTime();


        // CONSTRUCTOR
        public Map(PhysicsEngine map_physique)
        {
            MapTexture = new Rectangle(0, 0, 800, 480);
            this.map_physique = map_physique;
            this.liste_ia = new List<IA>();
            IA ia1 = new IA(120, 48, Ressources.IA1);
            IA ia2 = new IA(160, 48, Ressources.IA1);
            IA ia3 = new IA(400, 460, Ressources.IA2);/*
            this.liste_ia.Add(ia1);
            this.liste_ia.Add(ia2);
            this.liste_ia.Add(ia3);*/
            this.joueurs.Add(new Player(Keys.Up, Keys.Down, Keys.Left, Keys.Right, Keys.N, Ressources.Player1));/*
            this.joueurs.Add(new Player(Keys.Z, Keys.S, Keys.Q, Keys.D, Keys.A, Ressources.Player2));
            this.joueurs.Add(new Player(Keys.NumPad8, Keys.NumPad5, Keys.NumPad4, Keys.NumPad6, Keys.NumPad7, Ressources.Player3));*/

            this.liste_box = new List<Items>();
            this.liste_box2 = new List<Items>();

            this.liste_barrel = new List<DesctrutibleItems>();
            this.explosiveBox = new DesctrutibleItems(100, 100, "explosion");
            this.liste_barrel.Add(this.explosiveBox);
            this.liste_barrel2 = new List<DesctrutibleItems>();

            this.explosions = new List<ExplosionParticule>();
            this.explosions2 = new List<ExplosionParticule>();
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

        //Verifie la possibilité des actions du héros
        
        //En fonction des actions du héros, les vérifie et les appliquent aux différents moteurs.
                
        //Gère la collision entre le héros et les IA lors de son déplacement

        //Verifie la possibilité des actions de l'IA
        public void action_ia(IA ia)
        {
            foreach (DesctrutibleItems barrel in liste_barrel)
            {
                if (barrel.Aire_explosiveBox.Intersects(ia.rectangle()))
                {
                    ia.actionIA = "";
                }
            }

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
            ia.actionIA = ""; //"Remet à zéros" les actions de l'IA
        }

        public bool collision_entite_ia(IA ia)
        {
            futur_rectangle = this.ia.rectangle();
            bool test = true;
            foreach (IA ia1 in liste_ia)
            {
                if ((test) && !(ia1.est_update))
                {
                    test = !futur_rectangle.Intersects(ia1.rectangle/*_ia*/()); //Teste l'intersection entre une IA (parametre) et les autres (foreach) à l'aide de rectangle
                }
            }
            foreach (Player joueur in joueurs)
            {
                if (test)
                {
                    test = !futur_rectangle.Intersects(joueur.rectangle()); //Teste l'intersection entre une IA (parametre) et les héros (foreach) à l'aide de rectangle
                }
            }

            return test;
        }
        //Ces deux actions sont similaires à celles du héros

        //Gère le deplacement de l'ia
        public void pathfing(ref string action, Player joueur)
        {
            if (joueur.PlayerTexture.X < this.ia.IATexture.X)
            {
                action = "left";
                if (!(map_physique.mur(this.ia.futur_position_X_gauche(), this.ia.futur_position_Y_haut()))
                     && !(map_physique.mur(this.ia.futur_position_X_gauche(), this.ia.futur_position_Y_bas())))
                {
                }
                else
                {
                    if (joueur.PlayerTexture.Y < this.ia.IATexture.Y)
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
                    else if (joueur.PlayerTexture.Y > this.ia.IATexture.Y)
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
            else if (joueur.PlayerTexture.X > this.ia.IATexture.X)
            {
                action = "right";
                if (!(map_physique.mur(this.ia.futur_position_X_droite(), this.ia.futur_position_Y_haut()))
                     && !(map_physique.mur(this.ia.futur_position_X_droite(), this.ia.futur_position_Y_bas())))
                {
                }
                else
                {
                    action = "up";
                    if (joueur.PlayerTexture.Y < this.ia.IATexture.Y)
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
                    else if (joueur.PlayerTexture.Y > this.ia.IATexture.Y)
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
            else if (joueur.PlayerTexture.Y < this.ia.IATexture.Y)
            {
                action = "up";

                if (!(map_physique.mur(this.ia.futur_position_X_gauche(), this.ia.futur_position_Y_haut()))
                 && !(map_physique.mur(this.ia.futur_position_X_droite(), this.ia.futur_position_Y_haut())))
                {
                }
                else
                {
                    if (joueur.PlayerTexture.X < this.ia.IATexture.X)
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
                    else if (joueur.PlayerTexture.X > this.ia.IATexture.X)
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
            else if (joueur.PlayerTexture.Y > this.ia.IATexture.Y)
            {
                action = "down";
                if (!(map_physique.mur(this.ia.futur_position_X_gauche(), this.ia.futur_position_Y_bas()))
                 && !(map_physique.mur(this.ia.futur_position_X_droite(), this.ia.futur_position_Y_bas())))
                {
                }
                else
                {
                    action = "up";
                    if (joueur.PlayerTexture.Y < this.ia.IATexture.Y)
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
                    else if (joueur.PlayerTexture.Y > this.ia.IATexture.Y)
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
            else if (joueur.PlayerTexture.Y < this.ia.IATexture.Y)
            {
                action = "up";

                if (!(map_physique.mur(this.ia.futur_position_X_gauche(), this.ia.futur_position_Y_haut()))
                 && !(map_physique.mur(this.ia.futur_position_X_droite(), this.ia.futur_position_Y_haut())))
                {
                }
                else
                {
                    if (joueur.PlayerTexture.X < this.ia.IATexture.X)
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
                    else if (joueur.PlayerTexture.X > this.ia.IATexture.X)
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
        //Pathfinding, à modifier

        
        //Gère le raffraichissement de la liste d'IA
        public void update_ia()
        {
            foreach (IA ia in liste_ia) //Pour chaque IA de la liste
            {
                if (ia.Health > 0)
                {
                    ia.est_update = true; //Précise que l'on travaille sur la liste
                    this.ia = ia;
                    float distance = 10000;
                    Vector2 vector_ia = new Vector2(ia.IATexture.X, ia.IATexture.Y);
                    Player joueur_cible = new Player(Keys.Up, Keys.Down, Keys.Right, Keys.Left, Keys.S, Ressources.Player1);
                    Vector2 vector_joueur = new Vector2();                    
                    foreach (Player joueur in joueurs)
                    {
                        joueur_cible = joueur;
                        vector_joueur = new Vector2(joueur_cible.PlayerTexture.X, joueur_cible.PlayerTexture.Y);
                    }

                    Vector2.Distance(ref vector_ia, ref vector_joueur, out distance);
                    foreach (Player joueur in joueurs)
                    {
                        vector_joueur = new Vector2(joueur.PlayerTexture.X, joueur.PlayerTexture.Y);
                        float distance_2;
                        Vector2.Distance(ref vector_ia, ref vector_joueur, out distance_2);
                        if (distance_2 < distance)
                        {
                            distance = distance_2;
                            joueur_cible = joueur;
                        }
                    }
                    //L'ensemble des commandes précédentes définissent quel héros est la cible, ici le plus proche

                    pathfing(ref this.ia.action, joueur_cible); //Trouve quelle action va faire l'IA
                    action_ia(ia); //Verifie la possibilité de réalisation des actions
                    this.ia.Update(); //Met à jour l'IA
                    ia.attaque_ia(joueurs);
                    ia.est_update = false; //Désactive l'update de l'IA
                }
                else
                {
                    ia.en_vie = false; //Tue l'IA
                }
            }
            if (compteur > 180 && etape1) //Ajout de nouvelles IA a la map
            {
                int spawn = rand.Next(3);
                if (spawn == 0)
                {
                    int texture = rand.Next(2);
                    if (texture == 0)
                    {
                        liste_ia.Add(new IA(144, 48, Ressources.IA1));
                    }
                    else
                    {
                        liste_ia.Add(new IA(144, 48, Ressources.IA2));
                    }
                    int sons = rand.Next(2);
                    if (sons == 0)
                    {
                        moteur_son.PlayPika();
                    }
                    else
                    {
                        moteur_son.PlayPika2();
                    }

                }
                else if (spawn == 1)
                {
                    int texture = rand.Next(2);
                    if (texture == 0)
                    {
                        liste_ia.Add(new IA(0, 272, Ressources.IA1));
                    }
                    else
                    {
                        liste_ia.Add(new IA(0, 272, Ressources.IA2));
                    }
                    int sons = rand.Next(2);
                    if (sons == 0)
                    {
                        moteur_son.PlayPika();
                    }
                    else
                    {
                        moteur_son.PlayPika2();
                    }
                }
                else
                {
                    int texture = rand.Next(2);
                    if (texture == 0)
                    {
                        liste_ia.Add(new IA(400, 470, Ressources.IA1));
                    }
                    else
                    {
                        liste_ia.Add(new IA(400, 470, Ressources.IA2));
                    }
                    int sons = rand.Next(2);
                    if (sons == 0)
                    {
                        moteur_son.PlayPika();
                    }
                    else
                    {
                        moteur_son.PlayPika2();
                    }
                }

                compteur = 0;
            }
            compteur++;

            liste_ia2 = new List<IA>(); //Recopie la liste d'IA encore en vie dans une nouvelle liste
            foreach (IA ia in liste_ia)
            {
                if (ia.en_vie)
                    liste_ia2.Add(ia);
            }
            liste_ia = liste_ia2; //Vide la liste secondaire dans la premiere
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
                    balle.collision_entite_balle(liste_ia); //Collision entres balles et entité
                    balle.collision_balle(map_physique); //Collision entre balle et mur
                    collision_barrel_balle(balle);
                    balle.init++; //On bouge la balle d'une case
                }
            }

            foreach (Player joueur in joueurs) //On ajoute des balles en fonction des touches et du refroidissement
            {
                if ((keyboard.IsKeyDown(joueur.Tire)) && joueur.refroidissement >= 12 && etape1)
                {
                    balle = new Projectile(Ressources.Projectile, (int)joueur.centre().X, (int)joueur.centre().Y, 10, joueur.Direction, 50);
                    liste_projectile.Add(balle);
                    joueur.refroidissement = 0;
                    joueur.Ammo = joueur.Ammo - 1;
                    moteur_son.PlayTire();

                }
                joueur.refroidissement++;
            }

            liste_projectile2 = new List<Projectile>(); //On nettoie la liste, comme avec les IA
            foreach (Projectile balle in liste_projectile)
            {
                if (balle.isVisible)
                    liste_projectile2.Add(balle);
            }
            liste_projectile = liste_projectile2;
        }

        public void update_Box()
        {
            foreach (Items box in liste_box)
            {
                box.Update(joueurs);
            }
            liste_box2 = new List<Items>();
            foreach (Items box in liste_box)
            {
                if (box.isVisible)
                {
                    liste_box2.Add(box);
                }
            }
            liste_box = liste_box2;
        }

        public void update_Barrel()
        {
            foreach (DesctrutibleItems barrel in liste_barrel)
            {
                barrel.Update(joueurs);
            }
            liste_barrel2 = new List<DesctrutibleItems>();
            foreach (DesctrutibleItems barrel in liste_barrel)
            {
                if (barrel.isVisible)
                {
                    liste_barrel2.Add(barrel);
                }
            }
            liste_barrel = liste_barrel2;

            if (compteur > 180) //Ajout de nouveaux barrels a la map
            {
                int spawn = rand.Next(3);
                if (spawn == 0)
                {
                    int texture = rand.Next(2);
                    if (texture == 0)
                    {
                        liste_box.Add(new Items(510, 245, "health"));
                    }
                    else
                    {
                        liste_box.Add(new Items(510, 245, "ammo"));
                    }
                    moteur_son.PlayPop();
                }
                else if (spawn == 1)
                {
                    int texture = rand.Next(2);
                    if (texture == 0)
                    {
                        liste_box.Add(new Items(575, 200, "health"));
                    }
                    else
                    {
                        liste_box.Add(new Items(575, 200, "ammo"));
                    }
                    moteur_son.PlayPop();
                }
                else
                {
                    int texture = rand.Next(2);
                    if (texture == 0)
                    {
                        liste_box.Add(new Items(250, 30, "health"));
                    }
                    else
                    {
                        liste_box.Add(new Items(250, 30, "ammo"));
                    }
                    moteur_son.PlayPop();
                }

                compteur = 0;
            }
            compteur++;
        }

        public void collision_barrel_balle(Projectile balle) //S'occupe de la collision des balles avec les "barrels"
        {
            futur_rectangle = balle.rectangle();
            bool test = true;
            foreach (DesctrutibleItems barrel in liste_barrel) //Vérifie pour chaque "barrels"
            {
                if ((test)) //Permet de casser la boucle dès qu'un "barrel" est touché
                {
                    if (futur_rectangle.Intersects(barrel.Aire_explosiveBox)) //Si la HitBox du projectile est en contact avec celle du "barrel", alors (...)
                    {
                        balle.isVisible = false; //La balle n'existe plus
                        barrel.isVisible = false;
                        test = false; //On casse le si
                    }
                }
            }
        }

        private void AddExplosion(Vector2 position)
        {
            ExplosionParticule explosion = new ExplosionParticule();
            explosion.Initialize(Ressources.ExplosionParticule, position, 134, 134, 12, 45, Color.White, 1f, false);
            explosions.Add(explosion);
        }

        private void update_explosions(GameTime gameTime)
        {
            for (int i = explosions.Count - 1; i >= 0; i--)
            {
                explosions[i].Update(gameTime);
                if (explosions[i].Active == false)
                {
                    explosions.RemoveAt(i);
                }
            }
        }

        //Gère l'affichage de la liste d'IA
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
            //bool test = true;
            foreach (Player joueur in joueurs)
            {
                joueur.est_afficher = false;
            }
            foreach (IA ia in tableau_ia)
            {
                foreach (Player joueur in joueurs)
                {
                    if ((ia.IATexture.Y > joueur.PlayerTexture.Y) && !joueur.est_afficher)
                    {
                        joueur.Draw(spriteBatch);
                        joueur.est_afficher = true;

                    }

                    ia.Draw(spriteBatch);
                }


            }
            foreach (Player joueur in joueurs)
            {
                if (!joueur.est_afficher)
                {
                    joueur.Draw(spriteBatch);
                    joueur.est_afficher = true;

                }
            }
        }


        // UPDATE & DRAW
        public void Update(MouseState mouse, KeyboardState keyboard)
        {
            // Update l'objet joueur contenu par la map
            
            foreach (Player joueur in joueurs)
            {
                joueur.Update(mouse, keyboard);
                joueur.action_hero(map_physique,liste_ia, liste_barrel);
                if (joueur.Health > 0)
                {
                    joueurs_2.Add(joueur);
                }
            }
            joueurs = joueurs_2;
            joueurs_2 = new List<Player>();
            update_ia();
            update_Box();
            update_Barrel();
            update_explosions(gameTime);
            
            update_projectiles(keyboard);

            if (keyboard.IsKeyDown(Keys.D1) && !etape1)
            {
                etape1 = true;
            }

            if (keyboard.IsKeyDown(Keys.D2) && !etape2)
            {
                etape2 = true;
                this.joueurs.Add(new Player(Keys.Z, Keys.S, Keys.Q, Keys.D, Keys.A, Ressources.Player2));/*
                this.joueurs.Add(new Player(Keys.NumPad8, Keys.NumPad5, Keys.NumPad4, Keys.NumPad6, Keys.NumPad7, Ressources.Player3));*/
            }
            if (joueurs.Count == 0) //Si il n'y a plus de joueurs
            {
                game_over = true;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {

            spriteBatch.Draw(Ressources.Map, this.MapTexture, Color.CadetBlue);
            foreach (Items box in liste_box)
            {
                box.Draw(spriteBatch);
            }
            foreach (DesctrutibleItems barrel in liste_barrel)
            {
                barrel.Draw(spriteBatch);
            }
            for (int i = 0; i < explosions.Count; i++)
            {
                explosions[i].Draw(spriteBatch);
            }
            draw_ordre(spriteBatch);
            foreach (Projectile projectile in liste_projectile)
            {
                projectile.Draw(spriteBatch);
            }
        }
    }
}
