using System;
namespace StateApp
{
    class Program
    {
        static void Main()
        {
            Cursor cursor = new(new DefaultState());
            cursor.DisplayState();

            cursor.CursorState = new EraserState();
            cursor.DisplayState();

            cursor.CursorState = new ColorFillState();
            cursor.DisplayState();

            cursor.CursorState = new TextState();
            cursor.DisplayState();

            cursor.CursorState = new EyeDropperState();
            cursor.DisplayState();

            cursor.CursorState = new MagnifierState();
            cursor.DisplayState();

        }
    }
    public abstract class CursorState
    {
        public abstract void HandleState(Cursor cursor);
    }

    public class DefaultState : CursorState
    {
        public override void HandleState(Cursor cursor)
        {
            Console.WriteLine("Cursor is in Default State: Normal pointer.");
        }
    }
    public class PencilState : CursorState
    {
        public override void HandleState(Cursor cursor)
        {
            Console.WriteLine("Cursor is in Pencil State: Drawing lines.");
        }
    }
    public class EraserState : CursorState
    {
        public override void HandleState(Cursor cursor)
        {
            Console.WriteLine("Cursor is in Eraser State: Erasing content.");
        }
    }
    public class ColorFillState : CursorState
    {
        public override void HandleState(Cursor cursor)
        {
            Console.WriteLine("Cursor is in Color Fill State: Filling areas with color.");
        }
    }
    public class TextState : CursorState
    {
        public override void HandleState(Cursor cursor)
        {
            Console.WriteLine("Cursor is in Text State: Adding text.");
        }
    }
    public class EyeDropperState : CursorState
    {
        public override void HandleState(Cursor cursor)
        {
            Console.WriteLine("Cursor is in Eye Dropper State: Picking colors.");
        }
    }
    public class MagnifierState : CursorState
    {
        public override void HandleState(Cursor cursor)
        {
            Console.WriteLine("Cursor is in Magnifier State: Magnifying content.");
        }
    }

    public class Cursor(CursorState state)
    {
         CursorState currentState = state;

        public CursorState CursorState
        {
            get { return currentState; }
            set
            {
                currentState = value;
                Console.WriteLine("\nState: " + currentState.GetType().Name);
            }
        }

        public void DisplayState()
        {
            currentState.HandleState(this);
        }
    }


}