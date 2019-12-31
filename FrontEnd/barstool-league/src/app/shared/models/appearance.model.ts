import { Deserializable } from '../Interfaces/deserializable';

export class Appearance implements Deserializable {
    playerId: string;
    yearId: number;
    teamId: string;

    leagueId: string;

    gamesPlayed: number;
    gamesStarted: number;
    gamesBatting: number;
    gamesDefense: number;

    asPitcher: number;
    asCatcher: number;
    asFirstbaseman: number;
    asSecondbaseman: number;
    asThirdbaseman: number;
    asShortstop: number;
    asLeftfielder: number;
    asCenterfielder: number;
    asRightfielder: number;
    asOutfielder: number;
    asDesignatedHitter: number;
    asPinchHitter: number;
    asPinchRunner: number;

    public deserialize(input: any): this {
        // return strongly typed Appearance object from <any> type.
        const result = Object.assign(this, input);
        result.leagueId = input.LgID;
        result.gamesPlayed = input.g_all;
        result.gamesStarted = input.gs;
        result.gamesBatting = input.g_batting;
        result.gamesDefense = input.g_defense;
        result.asPitcher = input.g_p;
        result.asCatcher = input.g_c;
        result.asFirstbaseman = input.g_1b;
        result.asSecondbaseman = input.g_2b;
        result.asThirdbaseman = input.g_3b;
        result.asShortstop = input.g_ss;
        result.asLeftfielder = input.g_lf;
        result.asCenterfielder = input.g_cf;
        result.asRightfielder = input.g_rf;
        result.asOutfielder = input.g_of;
        result.asDesignatedHitter = input.g_dh;
        result.asPinchHitter = input.g_ph;
        result.asPinchRunner = input.g_pr;

        return result;
    }
}
