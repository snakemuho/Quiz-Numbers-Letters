using System.Collections.Generic;
using UnityEngine;

namespace QuizNumbersLetters.Grid.Interfaces
{
    public interface IGridGenerator
    {
        void SetGridData(GameObject gridBackground, Vector2 cellSize, Vector2 cellSpacing);
        List<Vector2> GenerateGridPositions(int rows, int columns);
    }
}