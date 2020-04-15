using System;
using UnityEngine;
/// <summary>
/// The four direction enumeration
/// </summary>
public enum Direction {
    North,
    East,
    South,
    West,
    Nothing,
    Northeast,
    Southeast,
    Southwest,
    Northwest,
}

public static class DirectionExtentions {
    public static Direction Perpendicular( this Direction dir ) {
        switch( dir ) {
            case Direction.West:
                dir = Direction.North;
                break;
            case Direction.Nothing:
                dir = Direction.Nothing;
                break;
            case Direction.Northwest:
                dir = Direction.Northeast;
                break;
            default:
                dir = (Direction)( ( (int)dir ) + 1 );
                break;
        }
        return dir;
    }

    public static Vector3 Angle( this Direction dir ) => new Vector3( 0.0f, (int)dir * 90.0f - 90.0f, 0.0f );

    public static float ToAngle45( this Direction dir ) {
        float result = 0.0f;
        switch( dir ) {
            case Direction.North:
                result = 0.0f;
                break;
            case Direction.Northeast:
                result = 45.0f;
                break;
            case Direction.East:
                result = 90.0f;
                break;
            case Direction.Southeast:
                result = 135.0f;
                break;
            case Direction.South:
                result = 180.0f;
                break;
            case Direction.Southwest:
                result = 225.0f;
                break;
            case Direction.West:
                result = 270.0f;
                break;
            case Direction.Northwest:
                result = 315.0f;
                break;
        }
        return result;
    }
    public static Coordinate ToCoord( this Direction dir ) {
        Coordinate result;
        switch( dir ) {
            case Direction.North:
                result = Coordinate.north;
                break;
            case Direction.West:
                result = Coordinate.west;
                break;
            case Direction.South:
                result = Coordinate.south;
                break;
            case Direction.East:
                result = Coordinate.east;
                break;
            case Direction.Northeast:
                result = Coordinate.northeast;
                break;
            case Direction.Southeast:
                result = Coordinate.southeast;
                break;
            case Direction.Southwest:
                result = Coordinate.southwest;
                break;
            case Direction.Northwest:
                result = Coordinate.northwest;
                break;
            default:
                result = Coordinate.zero;
                break;
        }
        return result;
    }

    public static float? ToAngle( this Direction dir ) {
        float? result = null;
        if( dir != Direction.Nothing )
            result = 90 * (float)dir;
        return result;
    }

    public static int GetQuadrant( this Direction dir ) {
        int result;
        switch( dir ) {
            case Direction.North:
                result = 0;
                break;
            case Direction.East:
                result = 1;
                break;
            case Direction.South:
                result = 2;
                break;
            case Direction.West:
                result = 3;
                break;
            default:
                result = 0;
                break;
        }
        return result;
    }

    public static Direction QuadrantRotate( this Direction dir, int quadrants ) {
        for( int i = 0; i < quadrants; i++ ) {
            switch( dir ) {
                case Direction.North:
                    dir = Direction.East;
                    break;
                case Direction.East:
                    dir = Direction.South;
                    break;
                case Direction.South:
                    dir = Direction.West;
                    break;
                case Direction.West:
                    dir = Direction.North;
                    break;
                case Direction.Northeast:
                    dir = Direction.Southeast;
                    break;
                case Direction.Southeast:
                    dir = Direction.Southwest;
                    break;
                case Direction.Southwest:
                    dir = Direction.Northwest;
                    break;
                case Direction.Northwest:
                    dir = Direction.Northeast;
                    break;
                default:
                    dir = Direction.Nothing;
                    break;
            }
        }
        return dir;
    }

    public static Direction ToDirection( this string type ) => (Direction)Enum.Parse( typeof( Direction ), type );


}
