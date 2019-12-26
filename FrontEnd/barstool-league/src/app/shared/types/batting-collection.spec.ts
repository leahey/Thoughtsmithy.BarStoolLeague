import { BattingCollection } from './batting-collection';
import { BattingStint } from '../models/batting-stint.model';
import { TestBed } from '@angular/core/testing';
import { RouterModule } from '@angular/router';
import { AppModule } from 'src/app/app.module';

describe('BattingCollection', () => {
    const battingStints = new Array<BattingStint>();
    let tested: BattingCollection = null;

    beforeEach(() => {
      TestBed.configureTestingModule({
        imports: [RouterModule, AppModule]
      });
      tested = new BattingCollection(battingStints);
    });

    it('should create an instance', () => {
      expect(new BattingCollection(battingStints)).toBeTruthy();
    });

    it('should have correct totalGamesPlayed', () => {
      expect(tested.totalGamesPlayed).toBe(360);
    });

    it('should have correct totalGamesBatting', () => {
      expect(tested.totalGamesBatting).toBe(344);
    });

    it('should have correct totalAtBats', () => {
      expect(tested.totalAtBats).toBe(1440);
    });

    it('should have correct totalRuns', () => {
      expect(tested.totalRuns).toBe(210);
    });

    it('should have correct totalHits', () => {
      expect(tested.totalHits).toBe(270);
    });

    it('should have correct totalDoubles', () => {
      expect(tested.totalDoubles).toBe(69);
    });

    it('should have correct totalTriples', () => {
      expect(tested.totalTriples).toBe(20);
    });

    it('should have correct totalHomeruns', () => {
      expect(tested.totalHomeruns).toBe(55);
    });

    it('should have correct totalRunsBattedIn', () => {
      expect(tested.totalRunsBattedIn).toBe(255);
    });

    it('should have correct totalStolenBases', () => {
      expect(tested.totalStolenBases).toBe(30);
    });

    it('should have correct totalCaughtStealing', () => {
      expect(tested.totalCaughtStealings).toBe(16);
    });

    it('should have correct totalBasesOnBalls', () => {
      expect(tested.totalBasesOnBalls).toBe(190);
    });

    it('should have correct totalStrikeOuts', () => {
      expect(tested.totalStrikeOuts).toBe(190);
    });

    it('should have correct totalIntetionalBasesOnBalls', () => {
      expect(tested.totalIntentionalBasesOnBalls).toBe(7);
    });

    it('should have correct totalHitByPitches', () => {
      expect(tested.totalHitByPitches).toBe(18);
    });

    it('should have correct totalSacrificeHits', () => {
      expect(tested.totalSacrificeHits).toBe(23);
    });

    it('should have correct totalSacrificeFlies', () => {
      expect(tested.totalSacrificeFlies).toBe(19);
    });

    it('should have correct totalGroundedIntoDoublePlays', () => {
      expect(tested.totalGroundedIntoDoublePlays).toBe(17);
    });

    beforeAll(() => {
      const batting01 = getNewBattingStint({
        playerId: 'test01', yearId: 2000, stint: 1, teamId: 'testTeam', leagueId: 'testLeague',
          // games, gBatting, atBats
          games: 100, gBatting: 90, atBats: 400,
          // runs, hits, doubles, triples, HRs
          runs: 50, hits: 80, doubles: 20, triples: 5, homeruns: 10,
          // RBI, stolen, caught, BB, strikeouts
          runsBattedIn: 70, stolenBases: 10, caughtStealing: 5, basesOnBalls: 50, strikeOuts: 50,
          // IBB, HBP, sacHits, sacFlies, GIDP
          intentionalBasesOnBalls: 3, hitByPitches: 5, sacrificeHits: 5, sacrificeFlies: 5, groundedIntoDoublePlays: 5
        });

      const batting02 = getNewBattingStint({
        playerId: 'test01', yearId: 2001, stint: 1, teamId: 'testTeam', leagueId: 'testLeague',
          // games, gBatting, atBats
          games: 120, gBatting: 118, atBats: 480,
          // runs, hits, doubles, triples, HRs
          runs: 70, hits: 90, doubles: 25, triples: 7, homeruns: 15,
          // RBI, stolen, caught, BB, strikeouts
          runsBattedIn: 85, stolenBases: 12, caughtStealing: 9, basesOnBalls: 60, strikeOuts: 60,
          // IBB, HBP, sacHits, sacFlies, GIDP
          intentionalBasesOnBalls: 2, hitByPitches: 3, sacrificeHits: 8, sacrificeFlies: 4, groundedIntoDoublePlays: 8
        });

      const batting03a = getNewBattingStint({
        playerId: 'test01', yearId: 2002, stint: 1, teamId: 'testTeam', leagueId: 'testLeague',
          // games, gBatting, atBats
          games: 70, gBatting: 68, atBats: 280,
          // runs, hits, doubles, triples, HRs
          runs: 45, hits: 50, doubles: 12, triples: 4, homeruns: 15,
          // RBI, stolen, caught, BB, strikeouts
          runsBattedIn: 50, stolenBases: 4, caughtStealing: 1, basesOnBalls: 40, strikeOuts: 40,
          // IBB, HBP, sacHits, sacFlies, GIDP
          intentionalBasesOnBalls: 1, hitByPitches: 5, sacrificeHits: 5, sacrificeFlies: 5, groundedIntoDoublePlays: 2
        });

      const batting03b = getNewBattingStint({
        playerId: 'test01', yearId: 2002, stint: 2, teamId: 'testTeam2', leagueId: 'testLeague2',
          // games, gBatting, atBats
          games: 70, gBatting: 68, atBats: 280,
          // runs, hits, doubles, triples, HRs
          runs: 45, hits: 50, doubles: 12, triples: 4, homeruns: 15,
          // RBI, stolen, caught, BB, strikeouts
          runsBattedIn: 50, stolenBases: 4, caughtStealing: 1, basesOnBalls: 40, strikeOuts: 40,
          // IBB, HBP, sacHits, sacFlies, GIDP
          intentionalBasesOnBalls: 1, hitByPitches: 5, sacrificeHits: 5, sacrificeFlies: 5, groundedIntoDoublePlays: 2
        });

      battingStints.push(batting01);
      battingStints.push(batting02);
      battingStints.push(batting03a);
      battingStints.push(batting03b);
    });

    function getNewBattingStint({ playerId, yearId, stint, teamId, leagueId,
      games, gBatting, atBats,
      runs, hits, doubles, triples, homeruns,
      runsBattedIn, stolenBases, caughtStealing, basesOnBalls, strikeOuts,
      intentionalBasesOnBalls, hitByPitches, sacrificeHits, sacrificeFlies, groundedIntoDoublePlays
      }:
      { playerId: string; yearId: number; stint: number; teamId: string; leagueId: string;
        games: number; gBatting: number; atBats: number;
        runs: number; hits: number; doubles: number; triples: number; homeruns: number;
        runsBattedIn: number; stolenBases: number; caughtStealing: number; basesOnBalls: number; strikeOuts: number;
        intentionalBasesOnBalls: number; hitByPitches: number; sacrificeHits: number; sacrificeFlies: number;
        groundedIntoDoublePlays: number; }
      ):
      BattingStint {
        const result = new BattingStint();
        result.playerId = playerId;
        result.yearId = yearId;
        result.stint = stint;
        result.teamId = teamId;
        result.leagueId = leagueId;
        result.games = games;
        result.gBatting = gBatting;
        result.atBats = atBats;
        result.runs = runs;
        result.hits = hits;
        result.doubles = doubles;
        result.triples = triples;
        result.homeruns = homeruns;
        result.runsBattedIn = runsBattedIn;
        result.stolenBases = stolenBases;
        result.caughtStealing = caughtStealing;
        result.basesOnBalls = basesOnBalls;
        result.strikeOuts = strikeOuts;
        result.intentionalBasesOnBalls = intentionalBasesOnBalls;
        result.hitByPitches = hitByPitches;
        result.sacrificeHits = sacrificeHits;
        result.sacrificeFlies = sacrificeFlies;
        result.groundedIntoDoublePlays = groundedIntoDoublePlays;

        return result;
    }
});
