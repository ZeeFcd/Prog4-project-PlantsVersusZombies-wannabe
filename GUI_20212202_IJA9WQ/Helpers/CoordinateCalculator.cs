using GUI_20212202_IJA9WQ.Logic;
using GUI_20212202_IJA9WQ.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI_20212202_IJA9WQ.Helpers
{
    public class CoordinateCalculator
    {
        double displayWidth;
        double displayHeight;
        IGameLogic logic;
        public CoordinateCalculator(double displayWidth, double displayHeight, IGameLogic logic)
        {
            this.logic = logic;
            this.displayWidth = displayWidth;
            this.displayHeight = displayHeight;
        }
        public void Resize(double displayWidth, double displayHeight) 
        {
            (int, int)[] oldcoords = new (int, int)[logic.Plants.Count];
            for (int i = 0; i < logic.Plants.Count; i++)
            {
                oldcoords[i] = WhichCellInGameMap(logic.Plants[i].PlaceX, logic.Plants[i].PlaceY);
            }
            this.displayWidth = displayWidth;
            this.displayHeight = displayHeight;

            for (int i = 0; i < logic.Plants.Count; i++)
            {
                logic.Plants[i].PlaceX = GameMapCellWidth * oldcoords[i].Item1 + LeftMapBorder; 
                logic.Plants[i].PlaceY = GameMapCellHeight * oldcoords[i].Item2 + UpperMapBorder;
            }
        }

        public double LeftMapBorder
        {
            get { return 0.25 * displayWidth; }
        }
        public double RightMapBorder
        {
            get { return 0.97 * displayWidth; }
        }
        public double UpperMapBorder
        {
            get { return 0.15 * displayHeight; }
        }
        public double LowerMapBorder
        {
            get { return 0.95 * displayHeight; }
        }

        public double GameMapCellWidth
        {
            get { return (RightMapBorder - LeftMapBorder) / 9; }
        }
        public double GameMapCellHeight
        {
            get { return (LowerMapBorder - UpperMapBorder) / 5; }
        }

        public double LeftShopBorder
        {
            get { return 0.01 * displayWidth; }
        }
        public double RightShopBorder
        {
            get { return 0.11 * displayWidth; }
        }
        public double UpperShopBorder
        {
            get { return 0.02 * displayHeight; }
        }
        public double LowerShopBorder
        {
            get { return 0.69 * displayHeight; }
        }


        public bool IsInGameMap(double x, double y) 
        {
            return LeftMapBorder < x && x < RightMapBorder && UpperMapBorder < y && y < LowerMapBorder;
        }
        public bool IsInShop(double x, double y)
        {
            return LeftShopBorder < x && x < RightShopBorder && UpperShopBorder < y && y < LowerShopBorder;
        }
        
        public int WhichCellInShop(double x, double y) 
        {            
            return (int)((y - UpperShopBorder) / (LowerShopBorder / 6));
        }

        public (int,int) WhichCellInGameMap(double x, double y) 
        {
            (int, int) gamecellcoords = 
                ((int)((x - LeftMapBorder) / GameMapCellWidth),
                (int)((y - UpperMapBorder) / GameMapCellHeight));
            //gamecellcoords.Item1 = (int)((x - LeftMapBorder) / GameMapCellWidth); 
            //gamecellcoords.Item2 = (int)((y - UpperMapBorder) / GameMapCellHeight);

            return gamecellcoords;
        }

        public (double, double) PlantCoords((double, double) oldcoords) 
        {
            (double, double) plantcoords;
            var oldplantcoords = WhichCellInGameMap(oldcoords.Item1, oldcoords.Item1);
            plantcoords.Item1= GameMapCellWidth* oldplantcoords.Item1 +LeftMapBorder;
            plantcoords.Item2=GameMapCellHeight*oldplantcoords.Item2 + UpperMapBorder;


            return plantcoords;
        }


    }
}
