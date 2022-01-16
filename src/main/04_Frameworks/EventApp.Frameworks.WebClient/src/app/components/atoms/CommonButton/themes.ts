export type CommonButtonTheme = {
    color: string;
    backgroundColor: string;
}

export type CommonButtonThemes = {
    [key: string]: CommonButtonTheme;
}

const CommonButtonThemes: CommonButtonThemes = {
    main: {
        color: "black",
        backgroundColor: "white"
    },
    alter: {
        color: "white",
        backgroundColor: "#BF3030"
    }
}

export default CommonButtonThemes;