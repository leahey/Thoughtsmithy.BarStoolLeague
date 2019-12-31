import { BattingStint } from './batting-stint.model';
import { Deserializable } from '../Interfaces/deserializable';
import { Appearance } from './appearance.model';
import { FieldingStint } from './fielding-stint.model';

export class Person implements Deserializable {
    playerId: string;

    birthYear: number;
    birthMonth: number;
    birthDay: number;
    birthCountry: string;
    birthState: string;
    birthCity: string;

    deathYear: number;
    deathMonth: number;
    deathDay: number;
    deathCountry: string;
    deathState: string;
    deathCity: string;

    nameFirst: string;
    nameLast: string;
    nameGiven: string;

    weight: number;
    height: number;

    bats: string;
    throws: string;
    debut: string;
    finalGame: string;

    retroID: string;
    bbrefID: string;

    allstarFull: Array<any>;
    appearances: Array<Appearance>;
    awardsPlayers: Array<any>;
    batting: Array<BattingStint>;
    battingPost: Array<any>;
    fielding: Array<FieldingStint>;
    fieldingOF: Array<any>;
    fieldingOFsplit: Array<any>;
    fieldingPost: Array<any>;
    hallOfFame: Array<any>;
    managers: Array<any>;
    managersHalf: Array<any>;
    pitching: Array<any>;
    pitchingPost: Array<any>;
    salaries: Array<any>;

    // Deserialize JSON object to Person
    public deserialize(input: any): this {
        Object.assign(this, input);
        this.batting = input.batting.map((b: any) => new BattingStint().deserialize(b));
        this.appearances = input.appearances.map((b: any) => new Appearance().deserialize(b));
        return this;
    }

    get isPlayer(): boolean {
        return this.appearances.length > 0;
    }
    get isManager(): boolean {
        return this.managers.length > 0;
    }

    get displayHeight(): string {
        return `${Math.floor(this.height / 12)}' ${this.height % 12}"`;
    }

    get birthDate(): string {
        return (this.birthYear != null) ?
        new Date(this.birthYear, this.birthMonth, this.birthDay).toDateString() :
        '';
    }

    get deathDate(): string {
        return (this.deathYear != null) ?
        new Date(this.deathYear, this.deathMonth, this.deathDay).toDateString() :
        '';
        }

    get placeOfBirth(): string {
        return (this.birthCity != null) ?
            `${this.birthCity} ${this.birthState}, ${this.birthCountry}` :
            '';
    }

    get placeOfDeath(): string {
        return (this.deathCity != null) ?
            `${this.deathCity} ${this.deathState}, ${this.deathCountry}` :
            '';
    }
}
