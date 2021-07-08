import styled from "styled-components";

export type TableRowContainerProps = {
    height: string;
}

export const TableRowContainer = styled.div<TableRowContainerProps>`
    height: ${props => props.height}
    width: 100%;
    display: flex;
    position: relative;
    flex-direction: row;
`