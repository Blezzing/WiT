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
        public enum TileNumber
        {
            TopLeft = 0,
            TopMiddle,
            TopRight,
            MiddleLeft,
            MiddleMiddle,
            MiddleRight,
            BottomLeft,
            BottomMiddle,
            BottomRight,
            InverseTopLeft,
            InverseTopRight,
            InverseBottomLeft,
            InverseBottomRight,
            InverseMiddleMiddle
        }

        public Boolean[,] BoolFloor;
        public TileNumber[,] TileFloor;

        private int _floorHeight = 128;
        private int _floorWidth  = 128;
        private WaveEngine.Framework.Services.Random _rng = new WaveEngine.Framework.Services.Random();

        public MapDesign()
        {
            //Initialize
            RandomizeBoolFloor();
            BuildTileFloor();
        }

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
                    //find tilfældig bool:
                    randomBool = _rng.NextBool();

                    //undtagelsen:
                    if (cellCol == 0 || cellCol == _floorWidth - cellSize || cellRow == 0 || cellRow == _floorHeight - cellSize)
                        randomBool = true;

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
                        
            for (int cellRow = 0; cellRow < _floorHeight; cellRow++)
            {
                for (int cellCol = 0; cellCol < _floorWidth; cellCol++)
                {
                    //Tile Logik
                    //True = bad
                    //False = good
                    
                    //Yderkanter:
                    if (cellRow == 0 || cellRow == _floorHeight-1)
                    {
                        TileFloor[cellRow, cellCol] = TileNumber.InverseMiddleMiddle;
                    }
                    else if (cellCol == 0 || cellCol == _floorWidth-1)
                    {
                        TileFloor[cellRow, cellCol] = TileNumber.InverseMiddleMiddle;
                    }
                    else
                    {
                        if (BoolFloor[cellRow,cellCol])
                        {
                            //COMPLETE THIS!
                        }
                        else
                        {

                        }
                    }

                }
            }
        }
        #endregion
    }
}
