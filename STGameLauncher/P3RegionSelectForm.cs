using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using System.Windows.Forms;

namespace STGameLauncher
{
    public partial class GameRegionSet : Form
    {
        public Game CurGame;

        public GameRegionSet()
        {
            InitializeComponent();
        }

        public GameRegionSet(Game game)
        {
            InitializeComponent();
            CurGame = game;

            physUS.Enabled = false;
            physEU.Enabled = false;
            physJP.Enabled = false;

            digUS.Enabled = false;
            digEU.Enabled = false;
            digJP.Enabled = false;
            digTW.Enabled = false;

            labDig.Enabled = false;
            labPhys.Enabled = false;

            regionSelectButtonShow();


        }

        private void GameRegionSet_Load(object sender, EventArgs e)
        {

        }

        public void regionSelectButtonShow()
        {
            switch(CurGame.Meta.Name) 
            {

                case "Sonic the Hedgehog (2006)":
                    labPhys.Enabled = true;

                    physUS.Enabled=true; 
                    physEU.Enabled=true;
                    physJP.Enabled=true;
                    break;

                case "Sonic Unleashed":
                    labDig.Enabled = true;
                    labPhys.Enabled=true;

                    digUS.Enabled=true;
                    digEU.Enabled=true;
                    physUS.Enabled = true;
                    physEU.Enabled = true;
                    physJP.Enabled = true;
                    break;

                case "Sonic Generations":

                    labPhys.Enabled = true;


                    physUS.Enabled = true;
                    physEU.Enabled = true;
                    break;

                case "Sonic the Hedgehog 4 Episode I":
                    labDig.Enabled = true;

                    digUS.Enabled = true;
                    digEU.Enabled = true;
                    digJP.Enabled = true;
                    digTW.Enabled = true;

                    break;

                case "Sonic the Hedgehog 4 Episode II":
                    labDig.Enabled = true;


                    digUS.Enabled = true;
                    digEU.Enabled = true;
                    digJP.Enabled = true;
                    digTW.Enabled = true;

                    break;

                case "Sonic the Hedgehog (Sega Vintage Collection)":
                    labDig.Enabled = true;

                    digUS.Enabled = true;
                    digEU.Enabled = true;

                    break;

                case "Sonic the Hedgehog 2 (Sega Vintage Collection)":
                    labDig.Enabled = true;


                    digUS.Enabled = true;
                    digEU.Enabled = true;

                    break;

                case "Sonic the Hedgehog CD (2011)":
                    labDig.Enabled = true;


                    digUS.Enabled = true;
                    digEU.Enabled = true;

                    break;

                case "Sonic the Fighters":

                    if (CurGame.Meta.GameType == LaunchContainer.launcher.GameTypes[9])
                    {
                        physUS.Enabled= true;
                        physJP.Enabled= true;
                        break;
                    }

                    labDig.Enabled = true;


                    digUS.Enabled = true;
                    digEU.Enabled = true;

                    break;

                case "Sonic Adventure DX":
                    labDig.Enabled = true;


                    digUS.Enabled = true;
                    digEU.Enabled = true;

                    break;

                case "Sonic Adventure 2: Battle":
                    labDig.Enabled = true;


                    digEU.Enabled = true;

                    break;

                case "Sonic && Sega All-Stars Racing":

                    labPhys.Enabled = true;


                    physUS.Enabled = true;
                    physEU.Enabled = true;
    
                    break;

                case "Sonic && All-Stars Racing Transformed":
                    labDig.Enabled = true;
                    labPhys.Enabled = true;


                    digEU.Enabled = true;

                    physUS.Enabled = true;
                    physEU.Enabled = true;

                    break;

                case "Sega Superstars Tennis":

                    labPhys.Enabled = true;

                    physUS.Enabled = true;
                    physEU.Enabled = true;

                    break;



            }
        }

        private void physUS_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void physEU_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            String buttStatus = "";

            if (physUS.Checked) { buttStatus = "physUS"; }
            if (physEU.Checked) { buttStatus = "physEU"; }
            if (physJP.Checked) { buttStatus = "physJP"; }
            if (digUS.Checked) { buttStatus = "digUS"; }
            if (digEU.Checked) { buttStatus = "digEU"; }
            if (digJP.Checked) { buttStatus = "digJP"; }
            if (digTW.Checked) { buttStatus = "digTW"; }

            if (buttStatus == "")
            {
                MessageBox.Show("Select a region!");
            }
            else
            {
                switch (buttStatus)
                {
                    case "physUS":
                        switch (CurGame.Meta.Name)
                        {
                            case "Sonic the Hedgehog (2006)":
                                CurGame.ExeLoc = "%RPCS3_GAMEID%:BLUS30008";
                                break;
                            case "Sonic Unleashed":
                                CurGame.ExeLoc = "%RPCS3_GAMEID%:BLUS30244";
                                break;
                            case "Sonic Generations":
                                CurGame.ExeLoc = "%RPCS3_GAMEID%:BLUS30612";
                                break;
                            case "Sonic && Sega All-Stars Racing":
                                CurGame.ExeLoc = "%RPCS3_GAMEID%:BLUS30342";
                                break;
                            case "Sonic && All-Stars Racing Transformed":
                                CurGame.ExeLoc = "%RPCS3_GAMEID%:BLUS30839";
                                break;
                            case "Sega Superstars Tennis":
                                CurGame.ExeLoc = "%RPCS3_GAMEID%:BLUS30123";
                                break;
                            case "Sonic the Fighters":
                                CurGame.ExeLoc = "sfight";
                                break;
                        }
                        break;

                    case "physEU":
                        switch (CurGame.Meta.Name)
                        {
                            case "Sonic the Hedgehog (2006)":
                                CurGame.ExeLoc = "%RPCS3_GAMEID%:BLES00028";
                                break;
                            case "Sonic Unleashed":
                                CurGame.ExeLoc = "%RPCS3_GAMEID%:NPEB01347";
                                break;
                            case "Sonic Generations":
                                CurGame.ExeLoc = "%RPCS3_GAMEID%:BLES01236";
                                break;
                            case "Sonic && Sega All-Stars Racing":
                                CurGame.ExeLoc = "%RPCS3_GAMEID%:BLES00750";
                                break;
                            case "Sonic && All-Stars Racing Transformed":
                                CurGame.ExeLoc = "%RPCS3_GAMEID%:BLES01646";
                                break;
                            case "Sega Superstars Tennis":
                                CurGame.ExeLoc = "%RPCS3_GAMEID%:BLES00232";
                                break;
                        }
                        break;

                    case "physJP":
                        switch (CurGame.Meta.Name)
                        {
                            case "Sonic the Hedgehog (2006)":
                                CurGame.ExeLoc = "%RPCS3_GAMEID%:BLJM60006";
                                break;
                            case "Sonic Unleashed":
                                CurGame.ExeLoc = "%RPCS3_GAMEID%:BLJM60112";
                                break;
                            case "Sonic the Fighters":
                                CurGame.ExeLoc = "schamp";
                                break;
                        }
                        break;

                    case "digUS":
                        switch (CurGame.Meta.Name)
                        {
                            case "Sonic Unleashed":
                                CurGame.ExeLoc = "%RPCS3_GAMEID%:NPUB31204";
                                break;
                            case "Sonic the Hedgehog 4 Episode I":
                                CurGame.ExeLoc = "%RPCS3_GAMEID%:NPUB30127";
                                break;
                            case "Sonic the Hedgehog 4 Episode II":
                                CurGame.ExeLoc = "%RPCS3_GAMEID%:NPUB30581";
                                break;
                            case "Sonic the Hedgehog (Sega Vintage Collection)":
                                CurGame.ExeLoc = "%RPCS3_GAMEID%:NPUB30442";
                                break;
                            case "Sonic the Hedgehog 2 (Sega Vintage Collection)":
                                CurGame.ExeLoc = "%RPCS3_GAMEID%:NPUB30443";
                                break;
                            case "Sonic the Hedgehog CD (2011)":
                                CurGame.ExeLoc = "%RPCS3_GAMEID%:NPUB30442";
                                break;
                            case "Sonic the Fighters":
                                CurGame.ExeLoc = "%RPCS3_GAMEID%:NPUB30927";
                                break;
                            case "Sonic Adventure DX":
                                CurGame.ExeLoc = "%RPCS3_GAMEID%:NPUB30249";
                                break;
                        }
                        break;

                    case "digEU":
                        switch (CurGame.Meta.Name)
                        {
                            case "Sonic Unleashed":
                                CurGame.ExeLoc = "%RPCS3_GAMEID%:NPEB01347";
                                break;
                            case "Sonic the Hedgehog 4 Episode I":
                                CurGame.ExeLoc = "%RPCS3_GAMEID%:NPEB00153";
                                break;
                            case "Sonic the Hedgehog 4 Episode II":
                                CurGame.ExeLoc = "%RPCS3_GAMEID%:NPEB00717";
                                break;
                            case "Sonic the Hedgehog (Sega Vintage Collection)":
                                CurGame.ExeLoc = "%RPCS3_GAMEID%:NPEB00478";
                                break;
                            case "Sonic the Hedgehog 2 (Sega Vintage Collection)":
                                CurGame.ExeLoc = "%RPCS3_GAMEID%:NPEB00477";
                                break;
                            case "Sonic the Hedgehog CD (2011)":
                                CurGame.ExeLoc = "%RPCS3_GAMEID%:NPEB00787";
                                break;
                            case "Sonic the Fighters":
                                CurGame.ExeLoc = "%RPCS3_GAMEID%:NPEB01162";
                                break;
                            case "Sonic Adventure DX":
                                CurGame.ExeLoc = "%RPCS3_GAMEID%:NPEB00304";
                                break;
                            case "Sonic Adventure 2: Battle":
                                CurGame.ExeLoc = "%RPCS3_GAMEID%:NPEB00856";
                                break;
                            case "Sonic && All-Stars Racing Transformed":
                                CurGame.ExeLoc = "%RPCS3_GAMEID%:NPEB01232";
                                break;

                        }
                        break;

                    case "digJP":
                        switch(CurGame.Meta.Name)
                        {
                            case "Sonic the Hedgehog 4 Episode I":
                                CurGame.ExeLoc = "%RPCS3_GAMEID%:NPJB00035";
                                break;
                            case "Sonic the Hedgehog 4 Episode II":
                                CurGame.ExeLoc = "%RPCS3_GAMEID%:NPJB00164";
                                break;
                        }
                        break;

                    case "digTW":
                        switch(CurGame.Meta.Name)
                        {
                            case "Sonic the Hedgehog 4 Episode I":
                                CurGame.ExeLoc = "%RPCS3_GAMEID%:NPHB00187";
                                break;
                            case "Sonic the Hedgehog 4 Episode II":
                                CurGame.ExeLoc = "%RPCS3_GAMEID%:NPHB00459";
                                break;
                        }
                        break;
                }
            }
        }

        private void GameRegionSet_FormClosed(object sender, FormClosedEventArgs e)
        {
            
        }
    }
}
