using UnityEngine;

namespace QuizNumbersLetters.Grid.Data
{
    [CreateAssetMenu(fileName = "New GridDifficultyData", menuName = "Grid Difficulty Data", order = 9)]
    public class GridDifficultyData : ScriptableObject
    {
        [SerializeField] 
        private int _rows;

        [SerializeField] 
        private int _columns;

        public int Rows => _rows;

        public int Columns => _columns;
    }
}