using StupidTemplate.Classes;
using StupidTemplate.Menu;
using SurgeX.Helpers;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using UnityEngine;

namespace PinkMenu.Managers

{

    public static class ThemeManager
    {
        private static int CurrentTheme = 0;
        private static Theme[] Themes = {

 new Theme {
        MenuColors = new ExtGradient[] {
            new ExtGradient {
                colors = new GradientColorKey[] {
                    new GradientColorKey(ColorHelper.darkBlue, 0f),
                    new GradientColorKey(new Color(0.0f, 0.0f, 0.3f), 0.5f),
                    new GradientColorKey(ColorHelper.darkBlue, 1f)
                }
            },
            new ExtGradient {
                colors = GetSolidGradient(Color.black)
            }
        },
        TextColors = new Color[] {
            Color.white,
            new Color(0.3f, 0.3f, 0.3f)
        },
        ButtonColors = new ExtGradient[] {
            new ExtGradient {
                colors = GetSolidGradient(new Color(0.0f, 0.0f, 0.3f))
            },
            new ExtGradient {
                colors = GetSolidGradient(Color.black)
            }
        },
        BoardColors = new ExtGradient[] {
            new ExtGradient {
                colors = GetSolidGradient(Color.black)
            },
            new ExtGradient {
                colors = GetSolidGradient(new Color(0.0f, 0.0f, 0.3f))
            }
        },
        SkyColors = new ExtGradient[] {
            new ExtGradient {
                colors = new GradientColorKey[] {
                    new GradientColorKey(new Color(0.0f, 0.0f, 0.3f), 0f),
                    new GradientColorKey(new Color(0.0f, 0.0f, 0.7f), 0.5f),
                    new GradientColorKey(new Color(0.0f, 0.0f, 0.3f), 1f)
                }
            },
            new ExtGradient {
                colors = GetSolidGradient(Color.black)
            }
        }
    },
    new Theme {
        MenuColors = new ExtGradient[] {
            new ExtGradient {
                colors = new GradientColorKey[] {
                    new GradientColorKey(new Color(0.05f, 0.0f, 0.2f), 0f),
                    new GradientColorKey(new Color(0.2f, 0.0f, 0.4f), 0.5f),
                    new GradientColorKey(new Color(0.05f, 0.0f, 0.2f), 1f)
                }
            },
            new ExtGradient {
                colors = GetSolidGradient(new Color(0.1f, 0.0f, 0.3f))
            }
        },
        TextColors = new Color[] {
            Color.white,
            new Color(0.7f, 0.7f, 0.9f)
        },
        ButtonColors = new ExtGradient[] {
            new ExtGradient {
                colors = GetSolidGradient(new Color(0.2f, 0.0f, 0.4f))
            },
            new ExtGradient {
                colors = GetSolidGradient(new Color(0.05f, 0.0f, 0.2f))
            }
        },
        BoardColors = new ExtGradient[] {
            new ExtGradient {
                colors = GetSolidGradient(new Color(0.1f, 0.0f, 0.3f))
            },
            new ExtGradient {
                colors = GetSolidGradient(new Color(0.2f, 0.0f, 0.4f))
            }
        },
        SkyColors = new ExtGradient[] {
            new ExtGradient {
                colors = new GradientColorKey[] {
                    new GradientColorKey(new Color(0.2f, 0.0f, 0.1f), 0f),
                    new GradientColorKey(new Color(0.5f, 0.0f, 0.3f), 0.5f),
                    new GradientColorKey(new Color(0.2f, 0.0f, 0.1f), 1f)
                }
            },
            new ExtGradient {
                colors = GetSolidGradient(new Color(0.2f, 0.0f, 0.3f))
            }
        }
    },
    new Theme {
        MenuColors = new ExtGradient[] {
            new ExtGradient {
                colors = new GradientColorKey[] {
                    new GradientColorKey(new Color(0.1f, 0.1f, 0.1f), 0f),
                    new GradientColorKey(new Color(0.3f, 0.3f, 0.3f), 0.5f),
                    new GradientColorKey(new Color(0.1f, 0.1f, 0.1f), 1f)
                }
            },
            new ExtGradient {
                colors = GetSolidGradient(new Color(0.2f, 0.2f, 0.2f))
            }
        },
        TextColors = new Color[] {
            new Color(0.9f, 0.9f, 0.9f),
            new Color(0.5f, 0.5f, 0.5f)
        },
        ButtonColors = new ExtGradient[] {
            new ExtGradient {
                colors = GetSolidGradient(new Color(0.3f, 0.3f, 0.3f))
            },
            new ExtGradient {
                colors = GetSolidGradient(new Color(0.1f, 0.1f, 0.1f))
            }
        },
        BoardColors = new ExtGradient[] {
            new ExtGradient {
                colors = GetSolidGradient(new Color(0.2f, 0.2f, 0.2f))
            },
            new ExtGradient {
                colors = GetSolidGradient(new Color(0.3f, 0.3f, 0.3f))
            }
        },
        SkyColors = new ExtGradient[] {
            new ExtGradient {
                colors = new GradientColorKey[] {
                    new GradientColorKey(new Color(0.1f, 0.1f, 0.1f), 0f),
                    new GradientColorKey(new Color(0.3f, 0.3f, 0.3f), 0.5f),
                    new GradientColorKey(new Color(0.1f, 0.1f, 0.1f), 1f)
                }
            },
            new ExtGradient {
                 colors = new GradientColorKey[] {
                    new GradientColorKey(new Color(0.1f, 0.1f, 0.1f), 0f),
                    new GradientColorKey(new Color(0.3f, 0.3f, 0.3f), 0.5f),
                    new GradientColorKey(new Color(0.1f, 0.1f, 0.1f), 1f)
                 }
            }
        }
    },
    new Theme {
        MenuColors = new ExtGradient[] {
            new ExtGradient {
                colors = new GradientColorKey[] {
                    new GradientColorKey(Color.black, 0f),
                    new GradientColorKey(new Color(0.0f, 0.0f, 1.0f), 0.5f),
                    new GradientColorKey(Color.black, 1f)
                }
            },
            new ExtGradient {
                colors = GetSolidGradient(Color.black)
            }
        },
        TextColors = new Color[] {
            Color.white,
            new Color(0.5f, 0.5f, 0.5f)
        },
        ButtonColors = new ExtGradient[] {
            new ExtGradient {
                colors = GetSolidGradient(new Color(0.0f, 0.0f, 1.0f))
            },
            new ExtGradient {
                colors = GetSolidGradient(Color.black)
            }
        },
        BoardColors = new ExtGradient[] {
            new ExtGradient {
                colors = new GradientColorKey[] {
                    new GradientColorKey(Color.black, 0f),
                    new GradientColorKey(new Color(0.0f, 0.0f, 1.0f), 0.5f),
                    new GradientColorKey(Color.black, 1f)
                }
            }
        },
        SkyColors = new ExtGradient[] {
            new ExtGradient {
                colors = new GradientColorKey[] {
                    new GradientColorKey(Color.blue, 0f),
                    new GradientColorKey(new Color(0.0f, 0.0f, 0.8f), 0.5f),
                    new GradientColorKey(Color.blue, 1f)
                }
            },
            new ExtGradient {
                colors = new GradientColorKey[] {
                    new GradientColorKey(Color.blue, 0f),
                    new GradientColorKey(new Color(0.0f, 0.0f, 0.8f), 0.5f),
                    new GradientColorKey(Color.blue, 1f)
                }
            }
        }
    },
    new Theme {
        MenuColors = new ExtGradient[] {
            new ExtGradient {
                colors = new GradientColorKey[] {
                    new GradientColorKey(new Color(0.2f, 0.0f, 0.2f), 0f),
                    new GradientColorKey(new Color(0.5f, 0.0f, 0.5f), 0.5f),
                    new GradientColorKey(new Color(0.2f, 0.0f, 0.2f), 1f)
                }
            },
            new ExtGradient {
                colors = GetSolidGradient(new Color(0.2f, 0.0f, 0.2f))
            }
        },
        TextColors = new Color[] {
            new Color(0.9f, 0.9f, 0.9f),
            new Color(0.5f, 0.0f, 0.5f)
        },
        ButtonColors = new ExtGradient[] {
            new ExtGradient {
                colors = GetSolidGradient(new Color(0.5f, 0.0f, 0.5f))
            },
            new ExtGradient {
                colors = GetSolidGradient(new Color(0.2f, 0.0f, 0.2f))
            }
        },
        BoardColors = new ExtGradient[] {
            new ExtGradient {
                colors = new GradientColorKey[] {
                    new GradientColorKey(new Color(0.2f, 0.0f, 0.2f), 0f),
                    new GradientColorKey(new Color(0.5f, 0.0f, 0.5f), 0.5f),
                    new GradientColorKey(new Color(0.2f, 0.0f, 0.2f), 1f)
                }
            }
        },
        SkyColors = new ExtGradient[] {
            new ExtGradient {
                colors = new GradientColorKey[] {
                    new GradientColorKey(new Color(0.2f, 0.2f, 0.2f), 0f),
                    new GradientColorKey(new Color(0.5f, 0.5f, 0.5f), 0.5f),
                    new GradientColorKey(new Color(0.2f, 0.2f, 0.2f), 1f)
                }
            }
        }
    },














};








        public static GradientColorKey[] GetSolidGradient(Color color)
        {
            return new GradientColorKey[] { new GradientColorKey(color, 0f), new GradientColorKey(color, 1f) };
        }

        public static int GetThemeIndex()
        {
            return CurrentTheme;
        }
        public static void NextTheme(string buttonText = "")
        {
            if ((Themes.Length - 1) <= CurrentTheme)
            {
                CurrentTheme = 0;
            }
            else
            {
                CurrentTheme++;
            }
            if (buttonText != "")
            {
                ButtonInfo Button = Main.GetIndex(buttonText);
                Button.overlapText = Button.buttonText + CurrentTheme;
            }
        }
        public static void LastTheme(string buttonText = "")
        {
            if (0 >= CurrentTheme)
            {
                CurrentTheme = (Themes.Length - 1);
            }
            else
            {
                CurrentTheme--;
            }

            if (buttonText != "")
            {
                ButtonInfo Button = Main.GetIndex(buttonText);
                Button.overlapText = Button.buttonText + CurrentTheme;
            }
        }
        public static Theme GetTheme()
        {
            return Themes[CurrentTheme];
        }
    }
    public class Theme
    {
        internal ExtGradient[] MenuColors;
        internal Color[] TextColors;
        internal ExtGradient[] ButtonColors;
        internal ExtGradient[] BoardColors;
        internal ExtGradient[] SkyColors;

        public ExtGradient GetBackground()
        {
            return MenuColors[0];
        }

        public ExtGradient GetOutline()
        {
            return MenuColors[1];
        }

        public Color GetText(bool enabled)
        {
            if (enabled)
            {
                return TextColors[1];
            }
            return TextColors[0];
        }

        public ExtGradient GetButton(bool enabled)
        {
            if (enabled)
            {
                return ButtonColors[1];
            }
            return ButtonColors[0];
        }

        public ExtGradient GetBoard(bool enabled)
        {
            if (enabled)
            {
                return BoardColors[1];
            }
            return BoardColors[0];
        }

        public ExtGradient GetSky(bool enabled)
        {
            if (enabled)
            {
                return SkyColors[1];
            }
            return SkyColors[0];
        }
    }
}