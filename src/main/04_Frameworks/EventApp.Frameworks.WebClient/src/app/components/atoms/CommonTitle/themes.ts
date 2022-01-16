export type CommonTitleTheme = {
    color: string;
}

export type CommonTitleThemes = {
    [key: string]: CommonTitleTheme;
}

const CommonTitleThemes: CommonTitleThemes = {
    main: {
        color: "black"
    },
    alter: {
        color: "white"
    }
}

export default CommonTitleThemes;