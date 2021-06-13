import { GameComponent } from "../components/game/game.component";

export interface system
{
    gameState: string;
    winner: number;
    START: string;
    GAME: string;
    END: string;
}