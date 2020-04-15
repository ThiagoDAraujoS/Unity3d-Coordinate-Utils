using UnityEngine;

//Coodinate object
[System.Serializable]
public struct Coordinate {
    public int x;
    public int y;

    public static readonly Coordinate north     = new Coordinate( 0, 1 );
    public static readonly Coordinate northeast = new Coordinate( 1, 1 );
    public static readonly Coordinate east      = new Coordinate( 1, 0 );
    public static readonly Coordinate southeast = new Coordinate( 1, -1 );
    public static readonly Coordinate south     = new Coordinate( 0, -1 );
    public static readonly Coordinate southwest = new Coordinate( -1, -1 );
    public static readonly Coordinate west      = new Coordinate( -1, 0 );
    public static readonly Coordinate northwest = new Coordinate( -1, 1 );
    public static readonly Coordinate up        = new Coordinate( 0, 1 );
    public static readonly Coordinate right     = new Coordinate( 1, 0 );
    public static readonly Coordinate down      = new Coordinate( 0, -1 );
    public static readonly Coordinate left      = new Coordinate( -1, 0 );
    public static readonly Coordinate zero      = new Coordinate( 0, 0 );
    public static readonly Coordinate one       = new Coordinate( 1, 1 );

    public static Coordinate operator *( Coordinate c1, int c2 ) => new Coordinate( c1.x * c2, c1.y * c2 );
    public static Coordinate operator /( Coordinate c1, int c2 ) => new Coordinate( c1.x / c2, c1.y / c2 );
    public static Coordinate operator +( Coordinate c1, Coordinate c2 ) => new Coordinate( c1.x + c2.x, c1.y + c2.y );
    public static Coordinate operator -( Coordinate c1, Coordinate c2 ) => new Coordinate( c1.x - c2.x, c1.y - c2.y );
    public static Coordinate operator +( Coordinate c1, Direction c2 ) => c1 + c2.ToCoord();
    public static Coordinate operator -( Coordinate c1, Direction c2 ) => c1 - c2.ToCoord();

    public Coordinate( int x, int y ) {
        this.x = x;
        this.y = y;
    }

    public override bool Equals( object obj ) {
        bool result = false;
        if( result.GetHashCode() == obj.GetHashCode() && obj.GetType() == typeof( Coordinate ) ) {
            Coordinate newObj = (Coordinate)obj;
            result = ( x == newObj.x && y == newObj.y );
        }
        return result;
    }

    public static bool operator ==( Coordinate c1, Coordinate c2 ) => ( c1.GetHashCode() == c2.GetHashCode() ) && ( c1.x == c2.x && c1.y == c2.y );
    public static bool operator !=( Coordinate c1, Coordinate c2 ) => !( c1.GetHashCode() == c2.GetHashCode() ) && ( c1.x == c2.x && c1.y == c2.y );
    public int Distance( Coordinate target ) => Mathf.Abs( x - target.x ) + Mathf.Abs( y - target.y );

    public static implicit operator Direction( Coordinate c ) {
        Direction result;

        if( c == north )
            result = Direction.North;

        else if( c == northeast )
            result = Direction.Northeast;

        else if( c == east )
            result = Direction.East;

        else if( c == southeast )
            result = Direction.Southeast;

        else if( c == south )
            result = Direction.South;

        else if( c == southwest )
            result = Direction.Southwest;

        else if( c == west )
            result = Direction.West;

        else if( c == northwest )
            result = Direction.Northwest;

        else
            result = Direction.Nothing;

        return result;
    }

    public override int GetHashCode() => unchecked(x * 31 + y);

    public Vector3 ToVector3( float value = 0.0f ) => new Vector3( x, value, y );

    public static implicit operator Vector3( Coordinate c ) => new Vector3( c.x, 0.0f, c.y );

    public override string ToString() => "[" + x + "/" + y + "]";

    public static implicit operator Coordinate( Vector3 vector ) => new Coordinate( Mathf.RoundToInt( vector.x ), Mathf.RoundToInt( vector.z ) );
    public static implicit operator Coordinate( Vector2 vector ) => new Coordinate( Mathf.RoundToInt( vector.x ), Mathf.RoundToInt( vector.y ) );

    public static Coordinate FromVector3( Vector3 vector ) => new Coordinate( Mathf.RoundToInt( vector.x ), Mathf.RoundToInt( vector.z ) );

    public Coordinate Flip() => new Coordinate( y, x );

    public void Foreach( System.Action<int, int> itr ) {
        for( int y = 0; y < this.y; y++ )
            for( int x = 0; x < this.x; x++ )
                itr( x, y );
    }
    public void Foreach( System.Action<Coordinate> itr ) {
        for( int y = 0; y < this.y; y++ )
            for( int x = 0; x < this.x; x++ )
                itr( new Coordinate( x, y ) );
    }
}