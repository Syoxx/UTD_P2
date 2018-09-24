using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace UTD_P2
{
	class MainMenu
	{
		Texture2D background;
		Texture2D playMenuButton;
		Texture2D exitMenuButton;
		Texture2D creditsMenuButton;

		public MainMenu(Texture2D background, Texture2D playMenuButton, Texture2D exitMenuButton, Texture2D creditsMenuButton)
		{
			this.background = background;
			this.playMenuButton = playMenuButton;
			this.exitMenuButton = exitMenuButton;
			this.creditsMenuButton = creditsMenuButton;
		}
	}
}
