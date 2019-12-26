import { BattingStint } from '../models/batting-stint.model';

export class BattingCollection {
    // TODO: will need to support BattingPost records as well
    constructor(public batting: Array<BattingStint>) { }

    get totalGamesPlayed(): number {
        let result = 0;
        this.batting.forEach(stint => result += stint.games);
        return result;
    }

    get totalGamesBatting(): number {
        let result = 0;
        this.batting.forEach(stint => result += stint.gBatting);
        return result;
    }

    get totalAtBats(): number {
        let result = 0;
        this.batting.forEach(stint => result += stint.atBats);
        return result;
    }

    get totalRuns(): number {
        let result = 0;
        this.batting.forEach(stint => result += stint.runs);
        return result;
    }

    get totalHits(): number {
        let result = 0;
        this.batting.forEach(stint => result += stint.hits);
        return result;
    }

    get totalDoubles(): number {
        let result = 0;
        this.batting.forEach(stint => result += stint.doubles);
        return result;
    }

    get totalTriples(): number {
        let result = 0;
        this.batting.forEach(stint => result += stint.triples);
        return result;
    }

    get totalHomeruns(): number {
        let result = 0;
        this.batting.forEach(stint => result += stint.homeruns);
        return result;
    }

    get totalRunsBattedIn(): number {
        let result = 0;
        this.batting.forEach(stint => result += stint.runsBattedIn);
        return result;
    }

    get totalStolenBases(): number {
        let result = 0;
        this.batting.forEach(stint => result += stint.stolenBases);
        return result;
    }

    get totalCaughtStealings(): number {
        let result = 0;
        this.batting.forEach(stint => result += stint.caughtStealing);
        return result;
    }

    get totalBasesOnBalls(): number {
        let result = 0;
        this.batting.forEach(stint => result += stint.basesOnBalls);
        return result;
    }

    get totalStrikeOuts(): number {
        let result = 0;
        this.batting.forEach(stint => result += stint.strikeOuts);
        return result;
    }

    get totalIntentionalBasesOnBalls(): number {
        let result = 0;
        this.batting.forEach(stint => result += stint.intentionalBasesOnBalls);
        return result;
    }

    get totalHitByPitches(): number {
        let result = 0;
        this.batting.forEach(stint => result += stint.hitByPitches);
        return result;
    }

    get totalSacrificeHits(): number {
        let result = 0;
        this.batting.forEach(stint => result += stint.sacrificeHits);
        return result;
    }

    get totalSacrificeFlies(): number {
        let result = 0;
        this.batting.forEach(stint => result += stint.sacrificeFlies);
        return result;
    }

    get totalGroundedIntoDoublePlays(): number {
        let result = 0;
        this.batting.forEach(stint => result += stint.groundedIntoDoublePlays);
        return result;
    }

    get totalYears(): number {
        let result = 0;
        this.batting.forEach(stint => {
            if (stint.stint === 1) {
                result += 1;
            }});
        return result;
    }

    get totalBattingStints(): number {
        return this.batting.length;
    }
}
