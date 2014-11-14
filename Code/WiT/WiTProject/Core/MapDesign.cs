#region Using Statements
using System;
using System.Collections.Generic;
using WaveEngine.Common;
using WaveEngine.Common.Graphics;
using WaveEngine.Common.Math;
using WaveEngine.Framework.Physics2D;
using WaveEngine.Components.Cameras;
using WaveEngine.Components.Graphics2D;
using WaveEngine.Components.Graphics3D;
using WaveEngine.Common.Input;
using WaveEngine.Framework;
using WaveEngine.Framework.Graphics;
using WaveEngine.Framework.Resources;
using WaveEngine.Framework.Services;
using WaveEngine.Framework.Managers;
#endregion

namespace WiTProject
{


    
    public class MapDesign
    {
        #region Values
        public Boolean[,] BoolFloor;
        public TileNumber[,] TileFloor;

        //public Texture2D FloorTexture;

        private int _floorHeight = 64;
        private int _floorWidth  = 64;
        #endregion

        #region Construktor
        public MapDesign()
        {
            //Initialize
            RandomizeBoolFloor();
            BuildTileFloor();
            //CombineTiles();
        }
        #endregion

        #region Beskæftigelse med boolsk tabel
        private void RandomizeBoolFloor()
        {
            int cellSize        = 16;

            //subject to change
            InitializeCells(cellSize);
            cellSize /= 2;
            ApplyAutomaton(cellSize, new int[] { 5, 6, 7, 8 }, new int[] { 3, 4, 5, 6, 7, 8 }, 5);
            cellSize /= 2;
            ApplyAutomaton(cellSize, new int[] { 5, 6, 7, 8 }, new int[] { 3, 4, 5, 6, 7, 8 }, 5);
            cellSize = 2;
            ApplyAutomaton(cellSize, new int[] { 5, 6, 7, 8 }, new int[] { 3, 4, 5, 6, 7, 8 }, 5);
        }

        private void InitializeCells(int cellSize)
        {
            BoolFloor = new Boolean[_floorHeight, _floorWidth];
            Boolean randomBool;

            for (int cellCol = 0; cellCol < _floorWidth; cellCol += cellSize)
            {
                for (int cellRow = 0; cellRow < _floorHeight; cellRow += cellSize)
                {

                    //undtagelsen:
                    if (cellCol == 0 || cellCol == _floorWidth - cellSize || cellRow == 0 || cellRow == _floorHeight - cellSize)
                        randomBool = true;
                    else
                        //find tilfældig bool:
                        randomBool = WaveServices.Random.NextBool();

                    //vidderekald:
                    FillCell(BoolFloor, cellCol, cellRow, cellSize, randomBool);
                }
            }
        }

        private void FillCell(Boolean[,] cells, int startcellCol, int startcellRow, int size, bool value)
        {
            for (int cellCol = startcellCol; cellCol < startcellCol + size; cellCol++)
            {
                for (int cellRow = startcellRow; cellRow < startcellRow + size; cellRow++)
                {
                    cells[cellRow, cellCol] = value;
                }
            }
        }

        private void ApplyAutomaton(int cellSize, int[] bornList, int[] surviveList, int numIterations)
        {
            //lav temp arracellRow
            Boolean[,] tempCells = new Boolean[_floorWidth, _floorHeight];
            Boolean newValue;
            int neighboors;

            //fcellRowld temp arracellRow med ncellRow data
            for ( ; numIterations > 0; numIterations--)
            {
                for (int cellCol = 0; cellCol < _floorWidth; cellCol += cellSize)
                {
                    for (int cellRow = 0; cellRow < _floorHeight; cellRow += cellSize)
                    {
                        //undtagelser:
                        if (cellCol == 0 || cellCol >= _floorWidth - cellSize || cellRow == 0 || cellRow >= _floorHeight - cellSize)
                        {
                            newValue = true;
                        }
                        //den generelle løsning
                        else
                        {
                            neighboors = 0;

                            neighboors += BoolFloor[cellRow - cellSize, cellCol - cellSize] ? 1 : 0;
                            neighboors += BoolFloor[cellRow - cellSize, cellCol] ? 1 : 0;
                            neighboors += BoolFloor[cellRow - cellSize, cellCol + cellSize] ? 1 : 0;
                            neighboors += BoolFloor[cellRow, cellCol - cellSize] ? 1 : 0;
                            neighboors += BoolFloor[cellRow, cellCol + cellSize] ? 1 : 0;
                            neighboors += BoolFloor[cellRow + cellSize, cellCol - cellSize] ? 1 : 0;
                            neighboors += BoolFloor[cellRow + cellSize, cellCol] ? 1 : 0;
                            neighboors += BoolFloor[cellRow + cellSize, cellCol + cellSize] ? 1 : 0;

                            newValue =
                                //should it be born?
                                (BoolFloor[cellRow, cellCol] == false && bornList.Contains(neighboors)) ||
                                //should it survive?
                                (BoolFloor[cellRow, cellCol] == true && surviveList.Contains(neighboors));

                            FillCell(tempCells, cellCol, cellRow, cellSize, newValue);
                        }
                    }
                }

                BoolFloor = tempCells.Copy(_floorWidth, _floorHeight);
            }
        }
        #endregion

        #region Beskæftigelse med tile tabel
        private void BuildTileFloor()
        {
            TileFloor = new TileNumber[_floorHeight, _floorWidth];
            Boolean left, top, right, bottom, d1, d2, d3, d4;
                        
            for (int cellRow = 0; cellRow < _floorHeight; cellRow++)
            {
                for (int cellCol = 0; cellCol < _floorWidth; cellCol++)
                {
                    //Tile Logik
                    //True = bad
                    //False = good
                    
                    //Yderkanter:
                    if (cellRow == 0 || cellRow == _floorHeight-1 || cellCol == 0 || cellCol == _floorWidth-1)
                    {
                        if (BoolFloor[cellRow, cellCol])
                            TileFloor[cellRow, cellCol] = TileNumber.InverseMiddleMiddle;
                        else
                            TileFloor[cellRow, cellCol] = TileNumber.MiddleMiddle;
                        
                    }
                    else
                    {
                        if (BoolFloor[cellRow, cellCol])
                        {
                            TileFloor[cellRow, cellCol] = TileNumber.InverseMiddleMiddle;
                        }
                        else
                        {
                            //Logik:
                            //  d1  2   d2
                            //  1   X   3
                            //  d4  4   d3
                            //
                            // true = bad
                            // false = good

                            left    = BoolFloor[cellRow, cellCol - 1];
                            top     = BoolFloor[cellRow - 1, cellCol];
                            right   = BoolFloor[cellRow, cellCol + 1];
                            bottom  = BoolFloor[cellRow + 1, cellCol];
                            d1      = BoolFloor[cellRow - 1, cellCol - 1];
                            d2      = BoolFloor[cellRow - 1, cellCol + 1];
                            d3      = BoolFloor[cellRow + 1, cellCol + 1];
                            d4      = BoolFloor[cellRow + 1, cellCol - 1];

                            //De første 9 sprites;
                            if (left && top && !right && !bottom)
                                TileFloor[cellRow, cellCol] = TileNumber.TopLeft;
                            else if (!left && top && !right && !bottom)
                                TileFloor[cellRow, cellCol] = TileNumber.TopMiddle;
                            else if (!left && top && right && !bottom)
                                TileFloor[cellRow, cellCol] = TileNumber.TopRight;
                            else if (left && !top && !right && !bottom)
                                TileFloor[cellRow, cellCol] = TileNumber.MiddleLeft;
                            else if (!left && !top && !right && !bottom)
                            {
                                if (d1)
                                    TileFloor[cellRow, cellCol] = TileNumber.InverseTopLeft;
                                else if (d2)
                                    TileFloor[cellRow, cellCol] = TileNumber.InverseTopRight;
                                else if (d3)
                                    TileFloor[cellRow, cellCol] = TileNumber.InverseBottomRight;
                                else if (d4)
                                    TileFloor[cellRow, cellCol] = TileNumber.InverseBottomLeft;
                                else
                                    TileFloor[cellRow, cellCol] = TileNumber.MiddleMiddle;
                            }
                            else if (!left && !top && right && !bottom)
                                TileFloor[cellRow, cellCol] = TileNumber.MiddleRight;
                            else if (left && !top && !right && bottom)
                                TileFloor[cellRow, cellCol] = TileNumber.BottomLeft;
                            else if (!left && !top && !right && bottom)
                                TileFloor[cellRow, cellCol] = TileNumber.BottomMiddle;
                            else if (!left && !top && right && bottom)
                                TileFloor[cellRow, cellCol] = TileNumber.BottomRight;


                        }
                    }

                }
            }
        }
        #endregion

        #region Overflødig kombination af tiles
        /*
        private void CombineTiles()
        {
            //Prepare texture;
            FloorTexture = new Texture2D() 
            { 
                Height = FloorHeight * TileData.TileSize, 
                Width = FloorWidth * TileData.TileSize,
                Levels = 1,
                Format = PixelFormat.R8G8B8A8 
            };

            //Prepare target
            int totalBytes = FloorTexture.Width * FloorTexture.Height * 4;
            FloorTexture.Data = new byte[1][][];
            FloorTexture.Data[0] = new byte[1][];
            FloorTexture.Data[0][0] = new byte[totalBytes];
            
            //Prepare sources
            int sourceIndex;
            int targetIndex;
            Color[] source;
            Byte[] target = FloorTexture.Data[0][0];

            //Perform logic itterér tiles, så pixels.
            for (int vT = 0; vT < FloorHeight; vT++)
            {
                for (int hT = 0; hT < FloorWidth; hT++)
                {
                    source = TileData.GetTile(TileEnviroment.Debug, TileFloor[vT, hT]).GetData();
                    
                    for (int vP = 0; vP < TileData.TileSize; vP++)
                    {
                        for (int hP = 0; hP < TileData.TileSize; hP++)
                        {
                            sourceIndex = vP * TileData.TileSize + hP;
                            targetIndex = (vT * FloorWidth * TileData.TileSize + vP * TileData.TileSize + hT * TileData.TileSize + hP) * 4;


                            target[targetIndex + 0] = source[sourceIndex].R;
                            target[targetIndex + 1] = source[sourceIndex].G;
                            target[targetIndex + 2] = source[sourceIndex].B;
                            target[targetIndex + 3] = source[sourceIndex].A;
                        }
                    }
                }
            }

            //??
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            /*
            int bytesPerTile = TileData.TileSize * TileData.TileSize * 4;
            int byteToFill;
            Color[] tileColorData;
            for (int tfRow = 0; tfRow < FloorHeight; tfRow++)
            {
                for (int tfCol = 0; tfCol < FloorWidth; tfCol++)
                {
                    tileColorData = TileData.GetTile(TileEnviroment.Debug, TileFloor[tfRow, tfCol]).GetData();

                    for (int byteToCopy = 0; byteToCopy < bytesPerTile; byteToCopy+= 4)
                    {
                        // offset + place in line + line //TileData.GetTile(TileEnviroment.Debug, TileFloor[tfRow, tfCol]).Data[0][0][byteToCopy];
                        byteToFill = (tfRow * tfCol * TileData.TileSize * 4) + (byteToCopy % TileData.TileSize * 4) + (((byteToCopy * 4) / (TileData.TileSize *4)) * (FloorWidth * TileData.TileSize * 4));
                        FloorTexture.Data[0][0][byteToFill]  =  data[byteToCopy / 4].R;
                        FloorTexture.Data[0][0][byteToFill+1] = data[byteToCopy / 4].G;
                        FloorTexture.Data[0][0][byteToFill+2] = data[byteToCopy / 4].B;
                        FloorTexture.Data[0][0][byteToFill+3] = data[byteToCopy / 4].A;
                    }
                }
            }
        }
        */
        #endregion

        #region Properties
        public int FloorHeight
        {
            get { return _floorHeight; }
        }

        public int FloorWidth
        {
            get { return _floorWidth; }
        }
        #endregion
    }
}
