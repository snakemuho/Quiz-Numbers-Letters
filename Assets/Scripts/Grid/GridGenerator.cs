using System.Collections.Generic;
using QuizNumbersLetters.Grid.Interfaces;
using UnityEngine;

namespace QuizNumbersLetters.Grid
{
    public class GridGenerator : IGridGenerator
    {
        private GameObject _gridBackground;
        private Vector2 _cellSize;
        private Vector2 _cellSpacing;

        public void SetGridData(GameObject gridBackground, Vector2 cellSize, Vector2 cellSpacing)
        {
            _gridBackground = gridBackground;
            _cellSize = cellSize;
            _cellSpacing = cellSpacing;
        }

        public IEnumerable<Vector2> GenerateGridPositions(int rows, int columns)
        {
            SetGridBackgroundSize(rows, columns);

            float startX = -(columns - 1) * (_cellSize.x + _cellSpacing.x) / 2;
            float startY = (rows - 1) * (_cellSize.y + _cellSpacing.y) / 2;
            Vector2 startPosition = new Vector2(startX, startY);
            
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < columns; col++)
                {
                    yield return startPosition + new Vector2(
                        col * (_cellSize.x + _cellSpacing.x),
                        -row * (_cellSize.y + _cellSpacing.y)
                        );
                }
            }
        }

        private void SetGridBackgroundSize(int rows, int columns)
        {
            _gridBackground.transform.localScale = new Vector3(
                (_cellSize.x + _cellSpacing.x) * columns + _cellSpacing.x,
                (_cellSize.y + _cellSpacing.y) * rows + _cellSpacing.y, 1
            );
        }
    }
}