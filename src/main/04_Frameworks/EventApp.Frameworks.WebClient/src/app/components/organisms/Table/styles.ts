import styled from "styled-components";

export const TableContainer = styled.div`
    height: 100%;
    width: 100%;
    display: flex;
    flex-direction: column;
    position: relative;
    background-color: lightgrey;
    border: 1px solid black;
    border-radius: 0.3rem;
    padding: 1rem;
    flex: 2;
`

export const RowsContainer = styled.div`
    height: 100%;
    width: 100%;
    display: flex;
    flex-direction: column;
    position: relative;
    border: 1px solid black;
    overflow-y: auto;
    min-height: 10rem;
`

export type HeadersContainerProps = {
    height: string;
}

export const HeadersContainer = styled.div<HeadersContainerProps>`
    height: ${props => props.height};
    width: 100%;
    display: flex;
    flex-direction: column;
    position: relative;
    border-top: 1px solid black;
    border-left: 1px solid black;
    border-right: 1px solid black;
`
export const TableTitleContainer = styled.div`
    font-weight: 600;
    font-size: 1.3rem;
    display: flex;
    position: relative;
    margin-bottom: 0.5rem;
`

export const TableButtonsContainer = styled.div`
    display: flex;
    position: relative;
    margin-bottom: 0.5rem;
    flex-direction: row;
`