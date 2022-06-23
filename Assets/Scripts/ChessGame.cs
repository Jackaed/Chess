﻿using Antichess.PlayerTypes;
using UnityEngine;

namespace Antichess
{
    public class ChessGame : MonoBehaviour
    {
        private RenderedBoard _board;
        private bool _renderBoard;
        private Player _white, _black;

        private void Start()
        {
            _board = new RenderedBoard();
            _white = new User(_board, true);
            _black = new User(_board, false);
        }

        private void Update()
        {
            var currentPlayer = _board.WhitesMove ? _white : _black;
            var attemptedMove = currentPlayer.SuggestMove();

            if (attemptedMove != null)
            {
                Debug.Log(attemptedMove);
                _board.MovePiece(attemptedMove);
            }

            _board.OnNewFrame();
        }
    }
}
