import { Deserializable } from '../Interfaces/deserializable';

export class BattingStint implements Deserializable {
    playerId: string;
    yearId: number;
    stint: number;

    teamId: string;
    leagueId: string;

    games: number;
    gBatting: number;
    atBats: number;
    runs: number;
    hits: number;
    doubles: number;
    triples: number;
    homeruns: number;
    runsBattedIn: number;
    stolenBases: number;
    caughtStealing: number;
    basesOnBalls: number;
    strikeOuts: number;
    intentionalBasesOnBalls: number;
    hitByPitches: number;
    sacrificeHits: number;
    sacrificeFlies: number;
    groundedIntoDoublePlays: number;

    public deserialize(input: any): this {
        // return strongly typed BattingStint object from <any> type.
        const result = Object.assign(this, input);
        result.games = input.g;
        result.gBatting = input.gBatting;
        result.atBats = input.ab;
        result.runs = input.r;
        result.hits = input.h;
        result.doubles = input._2B;
        result.triples = input._3B;
        result.homeruns = input.hr;
        result.runsBattedIn = input.rbi;
        result.stolenBases = input.sb;
        result.caughtStealing = input.cs;
        result.basesOnBalls = input.bb;
        result.strikeOuts = input.so;
        result.intentionalBasesOnBalls = input.ibb;
        result.hitByPitches = input.hbp;
        result.sacrificeHits = input.sh;
        result.sacrificeFlies = input.sf;
        result.groundedIntoDoublePlays = input.gidp;

        return result;
    }
}
